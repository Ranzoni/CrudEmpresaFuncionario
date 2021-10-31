using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using CrudEmpresaFuncionario.Dtos;
using CrudEmpresaFuncionario.Shared;
using CrudEmpresaFuncionario.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public class CompanyService : Notification, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task CreateAsync(Company company)
        {
            company.Validate();
            if (!company.IsValid)
            {
                AddNotifications(company.Notifications.Messages);
                return;
            }

            await _companyRepository.CreateAsync(company);
        }

        public async Task DeleteAsync(int id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        public async Task<PaginationResponse<List<Company>>> GetAsync(CompanyRequest companyRequest)
        {
            var query = _companyRepository.Get();
            if (!string.IsNullOrEmpty(companyRequest.Name))
                query = query. Where(c => c.Name.Contains(companyRequest.Name));

            var countCompanies = await query.CountAsync();
            var companies = await query
                .Skip((companyRequest.Page - 1) * companyRequest.Size)
                .Take(companyRequest.Size)
                .ToListAsync();

            return new PaginationResponse<List<Company>>(companies, companyRequest.Page, companyRequest.Size, countCompanies);
        }

        public async Task<List<Company>> GetAsync()
        {
            return await _companyRepository.Get().ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Company company)
        {
            var actualCompany = await _companyRepository.GetByIdAsync(company.Id);
            if (actualCompany == null)
            {
                AddNotification("A empresa informada para edição não existe.");
                return;
            }

            company.Validate();
            if (!company.IsValid)
            {
                AddNotifications(company.Notifications.Messages);
                return;
            }

            await _companyRepository.UpdateAsync(company);
        }

        public CollectionNotifications Validations()
        {
            return Notifications;
        }
    }
}
