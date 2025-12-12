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

    public class ReservaServicioController : ControllerBase
    {
        private readonly IReservaServicioRepository _reservaServicioRepository;

        public ReservaServicioController(IReservaServicioRepository reservaServicioRepository)
        {
            _reservaServicioRepository = reservaServicioRepository;
        }

        // GET: api/<ReservaController>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _reservaServicioRepository.GetAllAsync());


        // GET: api/<ReservaController>/5
        [HttpGet("{reservaId}/{servicioId}", Name = "GetByIdAsyncReservaServicio")]
        public async Task<IActionResult> GetByIdAsync(int reservaId, int servicioId)
        {
            var reservaServicio = await _reservaServicioRepository.GetByIdsAsync(reservaId, servicioId);
            if (reservaServicio == null) return NotFound();
            return Ok(reservaServicio);
        }

        // POST api/<ReservaController>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ReservaServicioDto dto)
        {
            var newReservaServicio = new ReservaServicio
            {
                ReservaId = dto.ReservaId,
                ServicioId = dto.ServicioId
            };

            var created = await _reservaServicioRepository.AddAsync(newReservaServicio);
            return CreatedAtRoute("GetByIdAsyncReservaServicio",
                 new { reservaId = created.ReservaId, servicioId = created.ServicioId },
                created);
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{reservaId}/{servicioId}")]
        public async Task<IActionResult> DeleteAsync(int reservaId, int servicioId)
        {
            var deleted = await _reservaServicioRepository.DeleteAsync(reservaId, servicioId);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
