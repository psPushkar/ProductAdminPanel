using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Pcart.Models
{
    [Table("ProductData")]
    public class ProductDetails
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(maximumLength: 15,
           ErrorMessage = "Name Should Be Smaller Than 15 Characters")]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        //[Required(ErrorMessage = "Please Enter Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Enter Price")]
        //[Required(ErrorMessage = "Please Enter Your Name")]
        public int Price { get; set; }
    }
}