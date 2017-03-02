using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCappli_rest.Models;
using MVCappli_rest.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MVCappli_rest.View_Models
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
                
        }

        public MovieFormViewModel(Movies movie)
        {
                Id=movie.Id;
                Name= movie.Name;
                ReleaseDate=movie.ReleaseDate;
                DateAdded=movie.DateAdded;
                NumberInStock=movie.NumberInStock;
                GenreId = movie.GenreId;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }


        public List<Genre> Genre { get; set; }
    }
}