using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MainProjectGym.DAL.Data.Models
{
    public class MembershipDetails
    {
        [Key]
        public int MembershipDetailsId { get; set; }
        public string MembershipName { get; set; }
        public string MembershipDetail { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> Sequence { get; set; }
    }
}
