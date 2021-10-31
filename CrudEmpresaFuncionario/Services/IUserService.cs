using CrudEmpresaFuncionario.Domain.Entities;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public interface IUserService
    {
        Task<User> GetByLogin(string userName, string password, int idCompany);
        Task CreateAsync(User user);
    }
}
