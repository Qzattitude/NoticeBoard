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
        private readonly string wwwrootDirectory =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Notice");

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard(AdminDashboardViewModel model)
        {
            model.Notice = Db.Notice.ToList();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Upload()
        {
            UploadNoticeViewModel model = new UploadNoticeViewModel();
            model.Users = await UserManager.GetUsersInRoleAsync("User");
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Upload(UploadNoticeViewModel model, IEnumerable<string>SelecteUserListId)
        {
            if (ModelState.IsValid)
            {
                //string uniqueFileName = null;
                string FilePath;
                string uniqueFileName;
                if (model.PdfFile != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.PdfFile.FileName);
                    FilePath = Path.Combine(wwwrootDirectory, uniqueFileName);
                    using (var strem = new FileStream(FilePath, FileMode.Create))
                    {
                        await model.PdfFile.CopyToAsync(strem);
                    }
                }
                else { return View(); }
                Notice newNotice = new Notice()
                {
                    Id = Guid.NewGuid(),
                    NoticeName = model.NoticeName,
                    NoticeLink = uniqueFileName,
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
