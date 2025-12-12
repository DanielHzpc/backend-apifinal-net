using ApiEmpresa.Models;

namespace ApiEmpresa.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva?> GetByIdAsync(int id);
        Task<Reserva> AddAsync(Reserva reserva);
        Task<Reserva?> UpdateAsync(int id, Reserva reserva);
        Task<bool> DeleteAsync(int id);
    }
}
