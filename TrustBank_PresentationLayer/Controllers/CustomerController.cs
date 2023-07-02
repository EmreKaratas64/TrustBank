using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrustBank_BusinessLayer.Abstract;
using TrustBank_DataAccessLayer.Concrete;
using TrustBank_DTOLayer.DTOs.AppUserDTOs;
using TrustBank_DTOLayer.DTOs.CustomerAccountActivityDTOs;
using TrustBank_EntityLayer.Concrete;

namespace TrustBank_PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        //CustomerAccountActivityManager customerAccountActivityManager = new CustomerAccountActivityManager(new EfCustomerAccountActivityDal());
        private readonly ICustomerAccountActivityService _customerAccountActivityService;
        public CustomerController(UserManager<AppUser> userManager, ICustomerAccountActivityService customerAccountActivityService)
        {
            _userManager = userManager;
            _customerAccountActivityService = customerAccountActivityService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto appUserEditDto = new AppUserEditDto()
            {
                Name = currentUser.Name,
                Surname = currentUser.Surname,
                City = currentUser.City,
                District = currentUser.District,
                Email = currentUser.Email,
                ImageUrl = currentUser.ImgUrl,
                PhoneNumber = currentUser.PhoneNumber,
            };
            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AppUserEditDto appUserEditDto)
        {
            if (ModelState.IsValid)
            {
                if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    user.Name = appUserEditDto.Name;
                    user.Surname = appUserEditDto.Surname;
                    user.District = appUserEditDto.District;
                    user.City = appUserEditDto.City;
                    user.ImgUrl = appUserEditDto.ImageUrl;
                    user.Email = appUserEditDto.Email;
                    user.PhoneNumber = appUserEditDto.PhoneNumber;
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                    ModelState.AddModelError("", "Şifreler eşleşmiyor!");
            }
            return View(appUserEditDto);
        }

        [HttpGet]
        public IActionResult SendMoney(string mycurrency)
        {
            ViewBag.mycurrency = mycurrency;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMoney(CustomerSendMoneyDto customerSendMoneyDto)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == customerSendMoneyDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();
            var senderAccountNumberId = context.CustomerAccounts.Where(x => x.AppUserID == user.Id).Where(z => z.CustomerAccountCurrency == "TRY").Select(y => y.CustomerAccountID).FirstOrDefault();

            var values = new CustomerAccountActivity()
            {
                SenderID = senderAccountNumberId,
                ActivityDate = DateTime.Now,
                ActivityType = "Havale",
                ReceiverID = receiverAccountNumberID,
                Amount = customerSendMoneyDto.Amount,
                ActivityDescription = customerSendMoneyDto.ActivityDescription,
            };
            _customerAccountActivityService.TInsert(values);
            return RedirectToAction("Profile", "Customer");
        }


        public PartialViewResult CustomerLayoutHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutScriptsPartial()
        {
            return PartialView();
        }
    }
}
