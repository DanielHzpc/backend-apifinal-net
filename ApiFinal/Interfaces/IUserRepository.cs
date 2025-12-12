using ApiEmpresa.Models;

namespace ApiEmpresa.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> RegisterAsync(User user);
    }
}
