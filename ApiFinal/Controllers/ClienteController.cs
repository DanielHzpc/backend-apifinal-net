using ApiEmpresa.DTOs;
using ApiEmpresa.Interfaces;
using ApiEmpresa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _clienteRepository.GetAllAsync());

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetByIdAsyncCliente")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ClienteDto dto)
        {
            var newCliente = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Estado = dto.Estado
            };

            var created = await _clienteRepository.AddAsync(newCliente);
            return CreatedAtRoute("GetByIdAsyncCliente",
                 new { id = created.Id },
                 created);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ClienteDto dto)
        {
            var updateCliente = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Estado = dto.Estado
            };

            var updated = await _clienteRepository.UpdateAsync(id, updateCliente);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _clienteRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
