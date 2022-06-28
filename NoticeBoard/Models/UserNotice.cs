using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models
{
    public class UserNotice
    {
        [Key]
        public Guid Id { get; set; }
        public string NoticeId { get; set; }
        public string NoticePath { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsVisited { get; set; }
        public int ViewCount { get; set; }

        public virtual Notice Notice { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
