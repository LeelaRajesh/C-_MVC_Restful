﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCappli_rest.Dtos;
namespace MVCappli_rest.Models
{
    public class Min18YrsMembrForAPI : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerDto)validationContext.ObjectInstance;
            //var customerDto = new CustomerDto();
            //Mapper.Map<Customer, CustomerDto>(customer, customerDto);
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDay == null)
            {
                return new ValidationResult("Birth date is required");
            }

            var age = DateTime.Today.Year - customer.BirthDay.Value.Year;
            if (age < 18)
                return new ValidationResult("Customer must be atleast 18 years old to be a member");
            return ValidationResult.Success;
        }
    }
}