using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Models.VewModel;
using System.Threading.Tasks;

namespace NoticeBoard.Controllers
{
    [Authorize]
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

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    RedirectToAction("Index", "Home");
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
                    return RedirectToAction("Index", "Home");    
                }
            }
            return View(model);
        }

        [HttpPost]
        [AcceptVerbs("Get", "Post")]
        public JsonResult IsUserNameInUse(string Username)
        {
            //var result = await UserManager.FindByIdAsync(Username);
            //if (result == null)
            //{
            //    return Json(true);
            //}
            return Json($"Usename `{Username}` is already in use.");
        }
    }

    
}
