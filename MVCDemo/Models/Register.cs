using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Security.Principal;

namespace MVCDemo.Models
{
    public class Register
    {
        [ValidateNever]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter your FullName")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }



        [Required]
        [EmailAddress(ErrorMessage ="Please Enter valid EmailID")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not match")]
        public string ConfirmPassword { get; set; }

        [Range(18, 40)]
        public int Age { get; set; }

    }
}
