using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoticeBoard.Models;
namespace NoticeBoard.Controllers.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Notice> Notices { get; set; }
    }
}
