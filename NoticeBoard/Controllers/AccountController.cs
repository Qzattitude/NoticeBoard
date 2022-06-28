using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Models;
using NoticeBoard.Models.VewModel;
using System.Threading.Tasks;

namespace NoticeBoard.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Username
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                var result2 = await UserManager.AddToRoleAsync(user, "User");

                if (result.Succeeded && result2.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Login", "Account");
                }

            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.Username, 
                    model.Password,
                    model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (User.IsInRole("Admin")){
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else if (User.IsInRole("User")){
                        return RedirectToAction("Index", "User");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }

    
}
