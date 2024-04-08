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
        public int AddressId { get; set; }
        public virtual AddressModel Address { get; set; }
        public virtual ICollection<SessionCinemaModel> SessionsCinema { get; set; }
    }
}
