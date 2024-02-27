using System.ComponentModel.DataAnnotations;

namespace api_movie.Data.Dtos
{
    public class CinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int AddressId { get; set; }
    }
}
