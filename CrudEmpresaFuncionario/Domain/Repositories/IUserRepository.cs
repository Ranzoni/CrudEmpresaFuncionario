using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Shared;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string userName, string password);
    }
}
