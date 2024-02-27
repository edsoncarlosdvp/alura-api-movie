using System.ComponentModel.DataAnnotations;

namespace api_movie.Models
{
    public class AddressModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Number {  get; set; }
        public string Square { get; set; }
        public virtual CinemaModel Cinema { get; set; }
    }
}
