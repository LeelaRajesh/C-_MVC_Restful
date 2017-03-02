using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCappli_rest.Dtos;
using AutoMapper;

using MVCappli_rest.View_Models;
using MVCappli_rest.Models;
using System.Data.Entity;

namespace MVCappli_rest.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int Id)
        {
            
            foreach (var temp in _context.Customers.Include(c => c.MembershipType).ToList())
            {
                if (temp.Id == Id)
                {
                    return View(temp);
                }
            }
            return HttpNotFound();
        }

        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = membershiptypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var CustomerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                CustomerInDB.Name = customer.Name;
                CustomerInDB.BirthDay = customer.BirthDay;
                CustomerInDB.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
    }
}