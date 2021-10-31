using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using CrudEmpresaFuncionario.Infra;
using CrudEmpresaFuncionario.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace CrudEmpresaFuncionario.Tests.Domain.Services
{
    public class CompanyServiceTest
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

        private static ICompanyService GetCompanyService(ICompanyRepository companyRepository)
        {
            return new CompanyService(companyRepository);
        }

        private static async Task<Company> CreateCompany(ICompanyService companyService)
        {
            var newCompany = new Company(0, "Teste SA", 0, "1633112255")
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };

            await companyService.CreateAsync(newCompany);
            return newCompany;
        }

        [Fact]
        public async void ShouldCreateCompany()
        {
            var newCompany = new Company(0, "Teste SA", 0, "1633112255")
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };

            var companyService = GetCompanyService(GetInMemoryCompanyRepository());
            await companyService.CreateAsync(newCompany);
            var companyCreated = await companyService.GetByIdAsync(newCompany.Id);
            Assert.NotNull(companyCreated);
            Assert.Equal(0, companyService.Validations().Messages.Count);
        }

        [Fact]
        public async void ShouldNotCreateCompany()
        {
            var newCompany = new Company(0, "", 0, "1633112255")
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };

            var companyService = GetCompanyService(GetInMemoryCompanyRepository());
            await companyService.CreateAsync(newCompany);
            Assert.True(companyService.Validations().Messages.Count > 0 && newCompany.Id == 0);
        }

        [Fact]
        public async void ShouldUpdateCompany()
        {
            var companyService = GetCompanyService(GetInMemoryCompanyRepository());
            var company = await CreateCompany(companyService);
            company.Name = "Novo Nome";
            await companyService.UpdateAsync(company);
            var actualCompany = await companyService.GetByIdAsync(company.Id);
            Assert.Equal(company.Name, actualCompany.Name);
            Assert.Equal(0, companyService.Validations().Messages.Count);
        }

        [Fact]
        public async void ShouldNotUpdateCompany()
        {
            var companyService = GetCompanyService(GetInMemoryCompanyRepository());
            var company = await CreateCompany(companyService);
            company.Name = "";
            await companyService.UpdateAsync(company);
            var actualCompany = await companyService.GetByIdAsync(company.Id);
            Assert.NotEqual(company.Name, actualCompany.Name);
            Assert.True(companyService.Validations().Messages.Count > 0);
        }

        [Fact]
        public async void ShouldDeleteCompany()
        {
            var companyService = GetCompanyService(GetInMemoryCompanyRepository());
            var company = await CreateCompany(companyService);
            var wasCreated = await companyService.GetByIdAsync(company.Id) != null;
            await companyService.DeleteAsync(company.Id);
            var companyDeleted = await companyService.GetByIdAsync(company.Id) == null;
            Assert.True(wasCreated && companyDeleted);
        }
    }
}
