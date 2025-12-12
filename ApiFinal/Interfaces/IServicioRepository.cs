using ApiEmpresa.Models;

namespace ApiEmpresa.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> GetAllAsync();
        Task<Servicio?> GetByIdAsync(int id);
        Task<Servicio> AddAsync(Servicio servicio);
        Task<Servicio?> UpdateAsync(int id, Servicio servicio);
        Task<bool> DeleteAsync(int id);
    }
}
