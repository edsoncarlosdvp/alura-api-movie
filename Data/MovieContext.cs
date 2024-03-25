using api_movie.Models;
using Microsoft.EntityFrameworkCore;

namespace api_movie.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            
        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CinemaModel> Cinemas { get; set; }
        public DbSet<AddressModel> Address { get; set; }
        public DbSet<SessionCinemaModel> Session { get; set; }
    }
}
