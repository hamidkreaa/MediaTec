using MediaTec.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaTec.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //public List<Customer> Customers;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

           // Customers = new List<Customer>();
            //{
            //    new Customer{Id =1, Name = "Hamid Kreaa"},
            //    new Customer{Id =2, Name = "Farah Kreaa"}
            //};
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            // var customers = GetCustomers();
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
         
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "Hamid Kreaa" },
        //        new Customer { Id = 2, Name = "Farah Kreaa" }
        //    };
        //}
    }
}