﻿namespace api_movie.Data.Dtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadAddressDto Address { get; set; }
    }
}
