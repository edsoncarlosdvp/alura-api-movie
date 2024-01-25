﻿using api_movie.Data;
using api_movie.Data.Dtos;
using api_movie.Models;
using apimovie.Migrations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_movie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDto movieDto)
        {
            MovieModel movie = _mapper.Map<MovieModel>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<MovieModel> GetAllMovies([FromQuery] int skip = 0, [FromQuery] int take = 30)
        {
            return _context.Movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult? GetMovieById(int id)
        {
            var result = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
