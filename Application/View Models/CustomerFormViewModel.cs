using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCappli_rest.Models;
using MVCappli_rest.Dtos;

namespace MVCappli_rest.View_Models
{
    public class CustomerFormViewModel
    {
        public List<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}