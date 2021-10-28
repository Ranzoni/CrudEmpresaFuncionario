using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task CreateAsync(Company company)
        {
            await _companyRepository.CreateAsync(company);
        }

        public async Task DeleteAsync(int id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        public async Task<List<Company>> GetAsync()
        {
            return await _companyRepository.Get().ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Company company)
        {
            var actualCompany = await _companyRepository.GetByIdAsync(id);
            if (actualCompany == null || id != actualCompany.Id)
                return;

            company.Id = id;
            company.Address.Id = actualCompany.Address.Id;
            await _companyRepository.UpdateAsync(company);
        }
    }
}
