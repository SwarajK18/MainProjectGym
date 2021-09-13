using MainProjectGym.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainProjectGym.Services.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public Role Role { get; set; }
        public Membership Membership { get; set; }
        public bool IsActive { get; set; }
    }
}
