using System;
using System.Collections.Generic;

namespace NoticeBoard.Models.VewModel
{
    public class UserViewModel
    {
        public List<Notice> Notices { get; set; }
        public bool IsViewed { get; set; }
        public DateTime DateTime { get; set; }
    }
}
