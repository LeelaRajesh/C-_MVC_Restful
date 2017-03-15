using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCappli_rest.Models;
using MVCappli_rest.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace MVCappli_rest.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController ()
        {
            _context = new ApplicationDbContext();
        }
        //Get Api/Customers
        public IHttpActionResult GetCustomers(string query=null){
            var customersQuery= _context.Customers
                .Include(c=> c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        //Get Api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //Post Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
 
        }

        //Put api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                return NotFound();
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDB);
            _context.SaveChanges();
            return Ok(customerDto);
        }

        //Delete api/cstomers/1

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) 
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                return NotFound();
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }
    }
}
