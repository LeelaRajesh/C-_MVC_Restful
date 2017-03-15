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
            if (newRental.MoiveId.Count== 0)
                return BadRequest("No movies added to the list.");
            rental.Customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (rental.Customer == null)
                return BadRequest("Invalid Customer.");

            var movies = _context.Movies.Where(
                m => newRental.MoiveId.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MoiveId.Count)
                return BadRequest("One or more movieIds is not valid.");

            foreach (var mov in movies){
                if (mov.NumberAvailable == 0)
                    return BadRequest(mov.Id + " is not available");
                mov.NumberAvailable--;
                rental.Movie = mov;
                rental.DateRented = DateTime.Now.Date;
                _context.Rentals.Add(rental);
                _context.SaveChanges();
            }
            return Ok();
        }

        
    }
}
