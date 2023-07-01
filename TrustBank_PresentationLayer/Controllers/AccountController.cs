using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TrustBank_DTOLayer.DTOs.AppUserDTOs;
using TrustBank_EntityLayer.Concrete;
using TrustBank_PresentationLayer.Models;

namespace TrustBank_PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                AppUser appUser = new AppUser()
                {
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    UserName = appUserRegisterDto.Username,
                    City = "aaa",
                    District = "bbbb",
                    ImgUrl = "ccc",
                    ConfirmCode = random.Next(100000, 1000000)
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("TrustBank Admin", "coreblog@ilkportfolio.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();

                    bodyBuilder.TextBody = "Hesabınız için doğrulama kodu: " + appUser.ConfirmCode;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "TrustBank Hesap Onay Kodu";

                    SmtpClient client = new SmtpClient();
                    client.Connect("webmail.ilkportfolio.com", 587, false);
                    client.Authenticate("coreblog@ilkportfolio.com", "cr798*BK");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                    TempData["Mail"] = appUser.Email;
                    return RedirectToAction("MailVerify");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(appUserRegisterDto);
        }

        [HttpGet]
        public IActionResult MailVerify()
        {
            ViewBag.mail = TempData["Mail"];
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> MailVerify(ConfirmMail confirmMail)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(confirmMail.Mail);
                if (user == null) return NotFound();
                if (user.ConfirmCode.ToString() == confirmMail.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(confirmMail);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(appUserLoginDto.UserName, appUserLoginDto.Password, appUserLoginDto.RememberMe, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", "Customer");
                }
                else if (result.IsNotAllowed)
                    ModelState.AddModelError("", "Lütfen mail adresinizi doğrulayınız");
                else
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View(appUserLoginDto);
        }
    }
}
