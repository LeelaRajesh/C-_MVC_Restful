﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCappli_rest.Models;

namespace MVCappli_rest.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        
        [Min18YrsMembrForAPI]
        public DateTime? BirthDay { get; set; }
    }
}