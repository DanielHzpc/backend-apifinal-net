using ApiEmpresa.Data;
using ApiEmpresa.Interfaces;
using ApiEmpresa.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Repositories
{
    public class ReservaServicioRepository : IReservaServicioRepository
    {
        public readonly ApplicationDbContext _context;

        public ReservaServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservaServicio>> GetAllAsync() =>
           await _context.ReservaServicio.ToListAsync();

        public async Task<ReservaServicio?> GetByIdsAsync(int reservaId, int servicioId) =>
            await _context.ReservaServicio
            .FirstOrDefaultAsync(rs =>
                rs.ReservaId == reservaId &&
                rs.ServicioId == servicioId);

        public async Task<ReservaServicio> AddAsync(ReservaServicio reservaServicio)
        {
            _context.ReservaServicio.Add(reservaServicio);
            await _context.SaveChangesAsync();
            return reservaServicio;
        }


        public async Task<bool> DeleteAsync(int reservaId, int servicioId)
        {
            var existing = await GetByIdsAsync(reservaId, servicioId);
            if (existing == null) return false;

            _context.ReservaServicio.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
