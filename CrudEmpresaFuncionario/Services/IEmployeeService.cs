using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Dtos;
using CrudEmpresaFuncionario.Shared;
using CrudEmpresaFuncionario.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public interface IEmployeeService : INotification
    {
        Task<Employee> GetByIdAsync(int id);
        Task<PaginationResponse<List<Employee>>> GetByIdCompany(int idCompany, EmployeeRequest employeeRequest);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
