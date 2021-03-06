using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Dtos;
using CrudEmpresaFuncionario.Shared;
using CrudEmpresaFuncionario.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public interface ICompanyService : INotification
    {
        Task<Company> GetByIdAsync(int id);
        Task<PaginationResponse<List<Company>>> GetAsync(CompanyRequest companyRequest);
        Task<List<Company>> GetAsync();
        Task CreateAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(int id);
    }
}
