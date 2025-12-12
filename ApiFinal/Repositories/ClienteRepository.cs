using ApiEmpresa.Data;
using ApiEmpresa.Interfaces;
using ApiEmpresa.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore; 

namespace ApiEmpresa.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() =>
           await _context.Clientes.ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id) =>
            await _context.Clientes.FindAsync(id);

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente?> UpdateAsync(int id, Cliente cliente)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null) return null;
            existing.Nombre = cliente.Nombre;
            existing.Telefono = cliente.Telefono;
            existing.Estado = cliente.Estado;

            await _context.SaveChangesAsync();
            return existing;
        }

       public async Task<bool> DeleteAsync(int id)
       {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null) return false;
            _context.Clientes.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
