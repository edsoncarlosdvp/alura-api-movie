using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using api_movie.Data;
using api_movie.Data.Dtos;
using api_movie.Models;

namespace api_adress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public AdressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="adressDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResults</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpPost]
        public IActionResult AddAdress([FromBody] AdressDto adressDto)
        {
            AdressModel adress = _mapper.Map<AdressModel>(adressDto);

            _context.Adress.Add(adress);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAdressById), new { id = adress.Id }, adress);
        }

        /// <summary>
        /// Exibe todos os filmes contidos no banco de dados
        /// </summary>
        /// <param name="adressDto">Objeto com os campos necessários</param>
        /// <returns>IActionResults</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadAdressDto> GetAllAdresss()
        {
            return _mapper.Map<List<ReadAdressDto>>(_context.Adress);
        }

        [HttpGet("{id}")]
        public IActionResult? GetAdressById(int id)
        {
            var result = _context.Adress.FirstOrDefault(adress => adress.Id == id);

            if (result == null) return NotFound();
            var adressDto = _mapper.Map<AdressDto>(result);
            return Ok(adressDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdress(int id, [FromBody] UpdateAdressDto adressDto)
        {
            var adress = _context.Adress.FirstOrDefault(adress => adress.Id == id);

            if (adress == null) return NotFound();

            _mapper.Map(adressDto, adress);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateAdressPatch(int id, JsonPatchDocument<UpdateAdressDto> patch)
        {
            var adress = _context.Adress.FirstOrDefault(adress => adress.Id == id);

            if (adress == null) return NotFound();

            var adressPatch = _mapper.Map<UpdateAdressDto>(adress);

            patch.ApplyTo(adressPatch, ModelState);

            if (!TryValidateModel(adressPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(adressPatch, adress);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdress(int id)
        {
            var adress = _context.Adress.FirstOrDefault(adress => adress.Id == id);

            if (adress == null) return NotFound();

            _context.Remove(adress);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
