using ApiEmpresa.Models;

namespace ApiEmpresa.Interfaces
{
    public interface IReservaServicioRepository
    {
        Task<IEnumerable<ReservaServicio>> GetAllAsync();
        Task<ReservaServicio?> GetByIdsAsync(int reservaId, int servicioId);
        Task<ReservaServicio> AddAsync(ReservaServicio reservaServicio);
        Task<bool> DeleteAsync(int reservaId, int servicioId);
    }
}
