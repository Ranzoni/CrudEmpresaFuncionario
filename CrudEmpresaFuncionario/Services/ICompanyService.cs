using CrudEmpresaFuncionario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public interface ICompanyService
    {
        Task<Company> GetByIdAsync(int id);
        Task<List<Company>> GetAsync();
        Task CreateAsync(Company company);
        Task UpdateAsync(int id, Company company);
        Task DeleteAsync(int id);
    }
}
