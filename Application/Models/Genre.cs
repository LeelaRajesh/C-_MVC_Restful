using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCappli_rest.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name="Genre")]
        public string genre { get; set; }
    }
}