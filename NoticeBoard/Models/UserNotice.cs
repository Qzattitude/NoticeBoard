using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace NoticeBoard.Models
{
    public class UserNotice
    {
        [Key]
        public int Id { get; set; }
        public int NoticeId { get; set; }
        public Notice Notice { get; set; }
        public string Username { get; set; }
        public User User { get; set; }
        public bool IsVisited { get; set; }
        public int ViewCount { get; set; }
       
    }
}
