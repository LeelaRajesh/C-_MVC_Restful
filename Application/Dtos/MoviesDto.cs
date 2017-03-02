using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCappli_rest.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public GenreDto Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}