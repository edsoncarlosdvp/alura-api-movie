using api_movie.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_movie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static int id = 0;
        private static List<MovieModel> movies = new List<MovieModel>();

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieModel movie)
        {
            movie.Id = id++;
            movies.Add(movie);

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<MovieModel> GetAllMovies([FromQuery] int skip = 0, [FromQuery] int take = 30)
        {
            return movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult? GetMovieById(int id)
        {
            var result = movies.FirstOrDefault(movie => movie.Id == id);

            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
