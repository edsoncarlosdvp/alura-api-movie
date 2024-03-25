using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using api_movie.Data.Dtos;
using api_movie.Models;
using api_movie.Data;

namespace api_movie.Controllers
{
    public class SessionCinemaController
    {
        [ApiController]
        [Route("[controller]")]
        public class SessaoController : ControllerBase
        {
            private MovieContext _context;
            private IMapper _mapper;

            public SessaoController(MovieContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpPost]
            public IActionResult AddSession(SessionCinemaCreateDto dto)
            {
                SessionCinemaModel session = _mapper.Map<SessionCinemaModel>(dto);
                _context.Session.Add(session);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetSessionById), new { Id = session.Id }, session);
            }

            [HttpGet]
            public IEnumerable<SessionCinemaReadDto> GetAllSession()
            {
                return _mapper.Map<List<SessionCinemaReadDto>>(_context.Session.ToList());
            }

            [HttpGet("{id}")]
            public IActionResult GetSessionById(int id)
            {
                SessionCinemaModel session = _context.Session.FirstOrDefault(session => session.Id == id);
                if (session != null)
                {
                    SessionCinemaReadDto sessionDto = _mapper.Map<SessionCinemaReadDto>(session);

                    return Ok(sessionDto);
                }
                return NotFound();
            }
        }
    }
}
