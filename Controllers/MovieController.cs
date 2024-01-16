using api_movie.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_movie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<MovieModel> movies = new List<MovieModel>();

        [HttpPost]
        public void AddMovie([FromBody] MovieModel movie)
        {
            movies.Add(movie);
            Console.WriteLine(movie.Title);
            Console.WriteLine(movie.Genere);
            Console.WriteLine(movie.Duration);
        }
    }
}
