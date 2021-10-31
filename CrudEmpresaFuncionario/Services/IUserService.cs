using CrudEmpresaFuncionario.Domain.Entities;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public interface IUserService
    {
        Task<User> GetByLogin(string userName, string password);
        Task CreateAsync(User user);
    }
}
