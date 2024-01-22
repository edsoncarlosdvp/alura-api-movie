using System.ComponentModel.DataAnnotations;

namespace api_movie.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public String? Title { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "O genero do filme é obrigatório")]
        public String? Genere { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração do filme deve estar entre 70 e 600 minutos")]
        public int Duration { get; set; }
    }
}
