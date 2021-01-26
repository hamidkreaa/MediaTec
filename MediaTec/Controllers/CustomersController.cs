using MediaTec.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaTec.ViewModels;

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes= membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        //Create Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
            };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id ==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                // TryUpdateModel(customerInDB);
                //Mapper.Map(customer, customerInDB);

                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscriebedToNewsletter = customer.IsSubscriebedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {            
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)           
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("CustomerForm", viewModel);
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