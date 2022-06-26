using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models.VewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Max username length is 50!")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be 4 characters or more!")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwor Don't Match")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
