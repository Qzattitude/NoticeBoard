using System;
using System.Collections.Generic;

namespace NoticeBoard.Models.VewModel
{
    public class AdminDashboardViewModel
    {
        public List<Notice> Notices { get; set; }
        public int ViewCount { get; set; }
    }
}
