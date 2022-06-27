using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models.VewModel
{
    public class UploadNoticeViewModel
    {
        public string NoticeName { get; set; }
        public IFormFile File { get; set; }
        public DateTime DateTime { get; set; }
        public IList<IdentityUser> Users { get; set; }  
        public bool IsChecked { get; set; }

    }
}
