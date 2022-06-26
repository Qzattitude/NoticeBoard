using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models
{
    public class User : IdentityUser
    {
        //[Required]
        //[MaxLength(30, ErrorMessage = "Max username length is 50!")]
        //[Remote(action: "IsUserNameInUse", controller: "Account")]
        //public override string UserName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[MinLength(4, ErrorMessage = "Password must be 4 characters or more!")]
        //public string Password { get; set; }
        public List<UserNotice> UserNotice { get; set; }
    }
}
