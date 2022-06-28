using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models
{
    public class Notice
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string NoticeName { get; set; }

        [Required]
        public string NoticeLink { get; set; }
        public DateTime UploadTime { get; set; }
        public virtual ICollection<UserNotice> UserNotice { get; set; }
    }
}
