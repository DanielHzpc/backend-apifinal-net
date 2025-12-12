using ApiEmpresa.DTOs;
using ApiEmpresa.Interfaces;
using ApiEmpresa.Models;
using ApiEmpresa.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        // GET: api/<ReservaController>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _reservaRepository.GetAllAsync());


        // GET: api/<ReservaController>/5
        [HttpGet("{id}", Name = "GetByIdAsyncReserva")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null) return NotFound();
            return Ok(reserva);
        }

        // POST api/<ReservaController>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ReservasDto dto)
        {
            var newReserva = new Reserva
            {
                IdCliente = dto.IdCliente,
                FechaReserva = dto.FechaReserva,
                Estado = dto.Estado
            };

            var created = await _reservaRepository.AddAsync(newReserva);
            return CreatedAtRoute("GetByIdAsyncReserva",
                 new { id = created.Id },
                 created);
        }

        // PUT api/<ReservaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ReservasDto dto)
        {
            var updateReserva = new Reserva
            {
                IdCliente = dto.IdCliente,
                FechaReserva = dto.FechaReserva,
                Estado = dto.Estado
            };

            var updated = await _reservaRepository.UpdateAsync(id, updateReserva);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _reservaRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
