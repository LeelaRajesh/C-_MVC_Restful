using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCappli_rest.Models;
using MVCappli_rest.Dtos;


namespace MVCappli_rest.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //post api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            Rental rental = new Rental();
            rental.Customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            foreach (var mov in newRental.MoiveId){
                rental.Movie = _context.Movies.SingleOrDefault(m => m.Id == mov);
                rental.DateRented = DateTime.Now.Date;
                _context.Rentals.Add(rental);
                _context.SaveChanges();
            }

            return Ok();
        }

        
    }
}
