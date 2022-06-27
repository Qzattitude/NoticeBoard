using Microsoft.AspNetCore.Http;
using System;

namespace NoticeBoard.Models.VewModel
{
    public class UploadNoticeViewModel
    {
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
        public Notice Notice { get; set; }
        public IFormFile File { get; set; }
        public DateTime DateTime { get; set; }

    }
}
