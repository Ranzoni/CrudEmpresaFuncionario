using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using CrudEmpresaFuncionario.Infra;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CrudEmpresaFuncionario.Tests.Domain.Repositories
{
    public class CompanyRepositoryTest
    {
        private static ICompanyRepository GetInMemoryCompanyRepository()
        {
            var builder = new DbContextOptionsBuilder<CrudContext>();
            builder.UseInMemoryDatabase("crudempresafuncionario");
            var options = builder.Options;
            var crudContext = new CrudContext(options);
            crudContext.Database.EnsureDeleted();
            crudContext.Database.EnsureCreated();
            return new CompanyRepository(crudContext);
        }

        private static async Task<Company> CreateCompany(ICompanyRepository companyRepository)
        {
            var newCompany = new Company(0, "Teste SA", 0, "1633112255")
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };

            await companyRepository.CreateAsync(newCompany);
            return newCompany;
        }

        private static async Task<Company> CreateCompany(ICompanyRepository companyRepository, Company newCompany)
        {
            await companyRepository.CreateAsync(newCompany);
            return newCompany;
        }

        [Fact]
        public async void ShouldCreateCompany()
        {
            var companyRepository = GetInMemoryCompanyRepository();
            var newCompany = await CreateCompany(companyRepository);
            var company = await companyRepository.GetByIdAsync(newCompany.Id);
            Assert.NotNull(company);
        }

        [Fact]
        public async void ShouldUpdateCompany()
        {
            var companyRepository = GetInMemoryCompanyRepository();
            var company = await CreateCompany(companyRepository);
            company.Name = "Novo Nome";
            await companyRepository.UpdateAsync(company);
            var actualCompany = await companyRepository.GetByIdAsync(company.Id);
            Assert.Equal(company.Name, actualCompany.Name);
        }

        [Fact]
        public async void ShouldDeleteCompany()
        {
            var companyRepository = GetInMemoryCompanyRepository();
            var company = await CreateCompany(companyRepository);
            var wasCreated = await companyRepository.GetByIdAsync(company.Id) != null;
            await companyRepository.DeleteAsync(company.Id);
            var companyDeleted = await companyRepository.GetByIdAsync(company.Id) == null;
            Assert.True(wasCreated && companyDeleted);
        }

        [Fact]
        public async void ShouldGetAllCompanies()
        {
            var companiesToCreate = new List<Company>
            {
                new Company(0, "Teste SA 1", 0, "1633112255")
                {
                    Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                },
                new Company(0, "Teste SA 2", 0, "16999887000")
                {
                    Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                },
                new Company(0, "Teste SA 3", 0, "1633112255")
                {
                    Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                }
            };
            var companyRepository = GetInMemoryCompanyRepository();

            foreach (var company in companiesToCreate)
                await CreateCompany(companyRepository, company);

            var companies = await companyRepository.Get().ToListAsync();
            var idsCompanyReturned = companies.Select(c => c.Id);
            var idsCompanyCreated = companiesToCreate.Select(c => c.Id).ToList();
            var companiesWereReturned = idsCompanyReturned.Intersect(idsCompanyCreated).Count() == idsCompanyCreated.Count();
            Assert.True(companiesWereReturned);
        }
    }
}
