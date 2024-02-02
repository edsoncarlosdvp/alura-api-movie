using System.ComponentModel.DataAnnotations;

namespace api_movie.Models
{
    public class CinemaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
