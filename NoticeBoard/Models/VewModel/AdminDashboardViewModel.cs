using System;
using System.Collections.Generic;

namespace NoticeBoard.Models.VewModel
{
    public class AdminDashboardViewModel
    {
        public Notice SingleNotice { get; set; }
        public IList<Notice> Notice { get; set; }
    }
}
