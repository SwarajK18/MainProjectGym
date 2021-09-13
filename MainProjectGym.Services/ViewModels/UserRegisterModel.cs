using MainProjectGym.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MainProjectGym.Services.ViewModels
{
   public class UserRegisterModel
    {
        [Required(ErrorMessage = "Please provide First Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "First Name cannot be more than 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please provide Last Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Last Name cannot be more than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide Number")]
        [StringLength(maximumLength: 15, ErrorMessage = "Number cannot be more than 15 digits")]
        [MinLength(10, ErrorMessage = "Number cannot be less than 10 digits")]
        public string Number { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }
        public Role Role { get; set; }
        public Membership Membership { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }



        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //APPLICATION USER FIELDS
        
    
    }
}
