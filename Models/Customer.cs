using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class Customer
    {
        public int Id{ get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}