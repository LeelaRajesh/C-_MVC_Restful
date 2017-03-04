using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCappli_rest.Models;

namespace MVCappli_rest.Dtos
{
    public class NewRentalDto
    {
        public List<int> MoiveId { get; set; }
        public int CustomerId { get; set; }
    }
}