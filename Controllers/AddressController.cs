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
    public class AddressController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="addressDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResults</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressDto addressDto)
        {
            AddressModel address = _mapper.Map<AddressModel>(addressDto);

            _context.Address.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
        }

        /// <summary>
        /// Exibe todos os filmes contidos no banco de dados
        /// </summary>
        /// <param name="addressDto">Objeto com os campos necessários</param>
        /// <returns>IActionResults</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadAddressDto> GetAllAddress()
        {
            return _mapper.Map<List<ReadAddressDto>>(_context.Address);
        }

        [HttpGet("{id}")]
        public IActionResult? GetAddressById(int id)
        {
            var result = _context.Address.FirstOrDefault(address => address.Id == id);

            if (result == null) return NotFound();
            var addressDto = _mapper.Map<AddressDto>(result);
            return Ok(addressDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
        {
            var address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            _mapper.Map(addressDto, address);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateAddressPatch(int id, JsonPatchDocument<UpdateAddressDto> patch)
        {
            var address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            var addressPatch = _mapper.Map<UpdateAddressDto>(address);

            patch.ApplyTo(addressPatch, ModelState);

            if (!TryValidateModel(addressPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(addressPatch, address);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            _context.Remove(address);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
