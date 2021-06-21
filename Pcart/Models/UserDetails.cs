using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pcart.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pcart.Models
{
    [Table("UserData")]
    public class UserDetails
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(maximumLength: 15,
           ErrorMessage = "Name Should Be Smaller Than 15 Characters")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email type")]
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email")]
        [Remote("IsAlreadySignedUp", "SignUp", ErrorMessage = "Email Already registered!!")]
        //[CustomValidation((DataType.EmailAddress), "IsAlreadySignedUp", ErrorMessage ="Email Already Used! Try A New One")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter The Password")]
        [StringLength(maximumLength: 48, MinimumLength = 5,
           ErrorMessage = "Password Should Be Atleast of 5 characters")]
        //[RegularExpression("^[0-9]",ErrorMessage = "Password Should be A Number")]

        public string Password { get; set; }

        [NotMapped]

        [Display(Name = " Confirm Password")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter The Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords Dont Match")]
        public string Cpassword { get; set; }
    }

    //public class EmailValidation : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        CartContext cc = new CartContext();
    //        if(bool(cc.Dsusers.Find(value)) == true)
    //        {

    //        }
    //    }
    //}
}