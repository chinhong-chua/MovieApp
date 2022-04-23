using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieApp.Models;

namespace MovieApp.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes{ get; set; }
        public Customer Customer { get; set; }

        public string FormTitle
        {
            get
            {
                return Customer.Id != 0 ? "Edit Customer" : "Create Customer";
            }
        }
    }
}