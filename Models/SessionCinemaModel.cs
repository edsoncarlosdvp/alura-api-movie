using System.ComponentModel.DataAnnotations;

namespace api_movie.Models
{
    public class SessionCinemaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        public virtual MovieModel Movie { get; set; }
        public int? CinemaId { get; set; }
        public virtual CinemaModel Cinema { get; set; }
    }
}
