using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCappli_rest.Models
{
    public class Movies
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Display(Name="Number In Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public int NumberAvailable { get; set; }

    }
}