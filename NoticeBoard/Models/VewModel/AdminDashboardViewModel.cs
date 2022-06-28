using System;
using System.Collections.Generic;

namespace NoticeBoard.Models.VewModel
{
    public class AdminDashboardViewModel
    {
        public string NoticeName { get; set; }
        public string NoticePath { get; set; }
        public int VidewCount { get; set; }
        public DateTime UploadTime { get; set; }
        public IList<Notice> Notices { get; set; }
        public IList<UserNotice> UserNoticeList { get; set; }
    }
}
