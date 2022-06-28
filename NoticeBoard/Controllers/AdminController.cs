using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models;
using NoticeBoard.Models.VewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AppDbContext db,
            IHostingEnvironment hostingEnvironment)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Db = db;
            HostingEnvironment = hostingEnvironment;
        }

        private UserManager<IdentityUser> UserManager { get; }
        private SignInManager<IdentityUser> SignInManager { get; }
        private AppDbContext Db { get; }
        private IHostingEnvironment HostingEnvironment { get; }

        //[Authorize(Roles = "Admin")]
        //[HttpGet]
        [AllowAnonymous]
        public IActionResult Dashboard(AdminDashboardViewModel model)
        {
            var dbNotice = Db.Notice.AsQueryable();
            model.Notice = dbNotice.ToList();
            return View(model);
        }

        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload()
        {
            UploadNoticeViewModel model = new UploadNoticeViewModel();
            model.Users = await UserManager.GetUsersInRoleAsync("User");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Upload(UploadNoticeViewModel model, IEnumerable<string>SelecteUserListId)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                string FilePath = null;
                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "Notices/");
                    uniqueFileName = Guid.NewGuid().ToString() +"_"+model.File.FileName;
                    FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(FilePath, FileMode.Create));
                }
                Notice newNotice = new Notice()
                {
                    Id = Guid.NewGuid(),
                    NoticeName = model.NoticeName,
                    NoticeLink = FilePath,
                    UploadTime = DateTime.UtcNow.AddHours(6)
                };
                await Db.Notice.AddAsync(newNotice);
                await Db.SaveChangesAsync();

                UserNotice userNotice = new UserNotice();
                foreach (var userId in SelecteUserListId)
                {
                    var user = await UserManager.FindByIdAsync(userId);

                    userNotice.NoticeId = newNotice.Id.ToString();
                    userNotice.NoticeName = newNotice.NoticeName;
                    userNotice.NoticePath = uniqueFileName;
                    userNotice.UserId = userId;
                    userNotice.UserName = user.UserName;
                    userNotice.IsVisited = false;
                    userNotice.UploadTime = newNotice.UploadTime;
                }
                await Db.UserNotice.AddAsync(userNotice);
                await Db.SaveChangesAsync();

            }
            return RedirectToAction("Dashboard","Admin");
        }

    }
}
