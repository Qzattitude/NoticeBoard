using System;
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
        public int ViewCount { get; set; }
        public User User { get; set; }
    }
}
