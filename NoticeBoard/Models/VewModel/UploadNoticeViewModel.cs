using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models.VewModel
{
    public class UploadNoticeViewModel
    {
        [Required]
        public string NoticeName { get; set; }
        [Required]
        public IFormFile PdfFile { get; set; }
        public DateTime UploadTime { get; set; }
        public IList<IdentityUser> Users { get; set; }
    }
}
