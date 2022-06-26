using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NoticeBoard.Controllers
{
    public class AdministrationController : Controller
    {
        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        public RoleManager<IdentityRole> RoleManager { get; }
    }
}
