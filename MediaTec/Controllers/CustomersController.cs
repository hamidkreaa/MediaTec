using MediaTec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaTec.Controllers
{
    public class CustomersController : Controller
    {
        //public List<Customer> Customers;

        //public CustomersController()
        //{

        //     Customers = new List<Customer>();
        //    //{
        //    //    new Customer{Id =1, Name = "Hamid Kreaa"},
        //    //    new Customer{Id =2, Name = "Farah Kreaa"}
        //    //};
        //}

        // GET: Customers
        public ActionResult Index()
        {
            var Customers = GetCustomers();
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Hamid Kreaa" },
                new Customer { Id = 2, Name = "Farah Kreaa" }
            };
        }
    }
}