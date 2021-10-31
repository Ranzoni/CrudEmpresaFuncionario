using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Shared;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<int> CountAsync();
    }
}
