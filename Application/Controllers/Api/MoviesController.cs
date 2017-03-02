using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


using MVCappli_rest.Dtos;
using MVCappli_rest.Models;
using AutoMapper;
using MVCappli_rest.App_Start;

namespace MVCappli_rest.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/movies
        public IEnumerable<MoviesDto> GetMovies()
        {
            return _context.Movies.
                Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movies, MoviesDto>);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            var movieDto = new MoviesDto();
            Mapper.Map<Movies, MoviesDto>(movie, movieDto);
            return Ok(movieDto);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = new Movies();
            Mapper.Map<MoviesDto, Movies>(movieDto, movie);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int Id, MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            Mapper.Map<MoviesDto, Movies>(movieDto, movie);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
