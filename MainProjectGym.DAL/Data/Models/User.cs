using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MainProjectGym.DAL.Data.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please provide Date Of Birth")]
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please select Role")]
        public Role Role { get; set; }

        [Required(ErrorMessage = "Please Select Yoour Membership")]
        public Membership Membership { get; set; }
        public bool IsActive { get; set; }
        //public string Emailid { get; set; }
        //public string Address { get; set; }
        //public int? UserRoleTypeId { get; set; }
        //public string UserRoleType { get; set; }
    }
    public enum Membership
    {
        Platinum,
        Gold,
        Sliver,
        Bronze
    }
    public enum Role
    {
        Admin,
        User
    }
}
