using ApiEmpresa.Data;
using ApiEmpresa.Interfaces;
using ApiEmpresa.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        public readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync() =>
           await _context.Reservas.ToListAsync();

        public async Task<Reserva?> GetByIdAsync(int id) =>
            await _context.Reservas.FindAsync(id);

        public async Task<Reserva> AddAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<Reserva?> UpdateAsync(int id, Reserva reserva)
        {
            var existing = await _context.Reservas.FindAsync(id);
            if (existing == null) return null;
            existing.IdCliente = reserva.IdCliente;
            existing.FechaReserva = reserva.FechaReserva;
            existing.Estado = reserva.Estado;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Reservas.FindAsync(id);
            if (existing == null) return false;
            _context.Reservas.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
