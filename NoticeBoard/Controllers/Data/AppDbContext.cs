using Microsoft.EntityFrameworkCore;
using NoticeBoard.Models;
namespace NoticeBoard.Controllers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Notice> Notices { get; set; }
    }
}
