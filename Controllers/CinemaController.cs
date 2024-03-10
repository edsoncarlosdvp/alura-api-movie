using api_movie.Data;
using api_movie.Data.Dtos;
using api_movie.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_movie.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CinemaController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public CinemaController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um cinema ao banco de dados
        /// </summary>
        /// <param name="cinemaDto">Objeto com os campos necessários para criação de um cinema</param>
        /// <returns>IActionResults</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpPost]
        public IActionResult AddCinema([FromBody] CinemaDto cinemaDto)
        {
            CinemaModel cinema = _mapper.Map<CinemaModel>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(SearchCinemaById), new { Id = cinema.Id },
                cinemaDto);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> SearchAllCinema()
        {
            var listCinemas = _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
            return listCinemas;
        }

        [HttpGet("{id}")]
        public IActionResult SearchCinemaById(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null) 
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] CinemaDto cinemaDto) 
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null) 
            {
                return NotFound();
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            CinemaModel cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
            {
                return NotFound();
            }

            _context.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
