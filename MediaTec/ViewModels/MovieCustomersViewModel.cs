using MediaTec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTec.ViewModels
{
    public class MovieCustomersViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}