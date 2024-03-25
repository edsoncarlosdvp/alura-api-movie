using System.ComponentModel.DataAnnotations;

namespace api_movie.Models
{
    public class SessionCinemaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
