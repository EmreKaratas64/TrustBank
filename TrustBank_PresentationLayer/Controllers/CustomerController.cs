using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrustBank_DTOLayer.DTOs.AppUserDTOs;
using TrustBank_EntityLayer.Concrete;

namespace TrustBank_PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public CustomerController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ProfileAsync()
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
