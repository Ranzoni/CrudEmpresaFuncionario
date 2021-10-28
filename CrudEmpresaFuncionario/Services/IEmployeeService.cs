using CrudEmpresaFuncionario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetByIdCompany(int idCompany);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
