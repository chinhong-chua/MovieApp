using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModel;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {


        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<Customer> customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer() {Id = 1, Name = "John Smith"},
                new Customer() {Id = 2, Name = "Marry Jane"},
                new Customer() {Id = 3, Name = "Cruz CH"},
                new Customer() {Id = 4, Name = "Alex Tan"},
            };
        }
    }
}