using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Max username length is 50!")]
        public string Username { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Password must be 4 characters or more!")]
        public string Password { get; set; }
        public List<UserNotice> UserNotice { get; set; }
    }
}
