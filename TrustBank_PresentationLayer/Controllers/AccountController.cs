using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrustBank_DTOLayer.DTOs.AppUserDTOs;
using TrustBank_EntityLayer.Concrete;

namespace TrustBank_PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
                AppUser appUser = new AppUser()
                {
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    UserName = appUserRegisterDto.Username
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("MailVerify", "Account");
                }
            }
            return View(appUserRegisterDto);
        }
    }
}
