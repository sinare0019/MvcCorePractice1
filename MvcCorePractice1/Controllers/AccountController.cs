using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcCorePractice1.Models;

namespace MvcCorePractice1.Controllers
{
    public class AccountController : Controller
    {
    private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var register = await _userManager.CreateAsync(new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    PhoneNumber = model.Mobile
                }, model.Password);
                if (!register.Succeeded)
                {
                    foreach (var errors in register.Errors)
                    {
                        ModelState.AddModelError("خطا", errors.Description);
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}
