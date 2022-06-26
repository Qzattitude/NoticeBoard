using System;

namespace NoticeBoard.Models
{
    public class UserNotice
    {
        public Guid NoticeId { get; set; }
        public Notice Notice { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsVisited { get; set; }
        public int ViewCount { get; set; }

    }
}
