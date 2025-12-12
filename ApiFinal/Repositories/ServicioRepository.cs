using ApiEmpresa.Data;
using ApiEmpresa.Interfaces;
using ApiEmpresa.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        public readonly ApplicationDbContext _context;

        public ServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servicio>> GetAllAsync() =>
           await _context.Servicio.ToListAsync();

        public async Task<Servicio?> GetByIdAsync(int id) =>
            await _context.Servicio.FindAsync(id);

        public async Task<Servicio> AddAsync(Servicio servicio)
        {
            _context.Servicio.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task<Servicio?> UpdateAsync(int id, Servicio servicio)
        {
            var existing = await _context.Servicio.FindAsync(id);
            if (existing == null) return null;
            existing.Nombre = servicio.Nombre;
            existing.Descripcion = servicio.Descripcion;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Servicio.FindAsync(id);
            if (existing == null) return false;
            _context.Servicio.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
