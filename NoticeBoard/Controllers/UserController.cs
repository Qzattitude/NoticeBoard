using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Models.VewModel;

namespace NoticeBoard.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(UserViewModel model)
        {
            return View(model);
        }
    }
}
