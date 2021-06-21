using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pcart.Models
{
    public class UserLogin
    {
        [Display(Name = "Email Address:")]
        [Required(ErrorMessage = "The Email Address Is Required ")]
        [EmailAddress(ErrorMessage = "This Is Not A Valid Email")]
        public string Email { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Please Enter Password To Login")]
        public string Password { get; set; }
    }

}