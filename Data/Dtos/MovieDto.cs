﻿using System.ComponentModel.DataAnnotations;

namespace api_movie.Data.Dtos
{
    public class MovieDto
    {
        [StringLength(30)]
        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public string? Title { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "O genero do filme é obrigatório")]
        public string? Genere { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração do filme deve estar entre 70 e 600 minutos")]
        public int Duration { get; set; }
    }
}
