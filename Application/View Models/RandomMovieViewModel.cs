using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCappli_rest.Models;

namespace MVCappli_rest.View_Models
{
    public class RandomMovieViewModel
    {
        public List<Movies> Movie { get; set; }
        public List<Customer> Customers { get; set; }

    }
}