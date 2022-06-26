﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models
{
    public class Notice
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        public DateTime UploadTime { get; set; }
        public List<UserNotice> UserNotice { get; set; }
    }
}
