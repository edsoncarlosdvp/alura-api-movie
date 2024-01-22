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
        public void AddMovie([FromBody] MovieModel movie)
        {
            movie.Id = id++;
            movies.Add(movie);
            Console.WriteLine(movie.Title);
            Console.WriteLine(movie.Genere);
            Console.WriteLine(movie.Duration);
        }

        [HttpGet]
        public IEnumerable<MovieModel> GetAllMovies()
        {  
            return movies; 
        }

        [HttpGet("{id}")]
        public MovieModel? GetMovieById(int id)
        {
            return movies.FirstOrDefault(movie => movie.Id == id);
        }
    }
}
