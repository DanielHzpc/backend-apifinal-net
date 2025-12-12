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

    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        // GET: api/<ServicioController>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _servicioRepository.GetAllAsync());


        // GET: api/<ServicioController>/5
        [HttpGet("{id}", Name = "GetByIdAsyncServicio")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var reserva = await _servicioRepository.GetByIdAsync(id);
            if (reserva == null) return NotFound();
            return Ok(reserva);
        }

        // POST api/<ServicioController>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ServicioDto dto)
        {
            var newServicio = new Servicio
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            var created = await _servicioRepository.AddAsync(newServicio);
            return CreatedAtRoute("GetByIdAsyncServicio",
                 new { id = created.Id },
                 created);
        }

        // PUT api/<ServicioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ServicioDto dto)
        {
            var updateServicio = new Servicio
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            var updated = await _servicioRepository.UpdateAsync(id, updateServicio);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _servicioRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
