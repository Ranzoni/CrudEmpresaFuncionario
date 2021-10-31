using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using CrudEmpresaFuncionario.Infra;
using CrudEmpresaFuncionario.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace CrudEmpresaFuncionario.Tests.Domain.Services
{
    public class EmployeeServiceTest
    {
        private static IEmployeeRepository GetInMemoryEmployeeRepository()
        {
            var builder = new DbContextOptionsBuilder<CrudContext>();
            builder.UseInMemoryDatabase("crudempresafuncionario");
            var options = builder.Options;
            var crudContext = new CrudContext(options);
            crudContext.Database.EnsureDeleted();
            crudContext.Database.EnsureCreated();
            return new EmployeeRepository(crudContext);
        }

        private static IEmployeeService GetEmployeeService(IEmployeeRepository employeeRepository)
        {
            return new EmployeeService(employeeRepository);
        }

        private static async Task<Employee> CreateEmployee(IEmployeeService employeeService)
        {
            var newEmployee = new Employee(0, "Novo Funcionário", 0, 1234.56, 0)
            {
                Company =
                    new Company(0, "Teste SA", 0, "1633112255")
                    {
                        Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                    },
                Position = new Position(0, "Programador")
            };

            await employeeService.CreateAsync(newEmployee);
            return newEmployee;
        }

        private static async Task<Employee> CreateEmployee(IEmployeeService employeeService, Employee newEmployee)
        {
            await employeeService.CreateAsync(newEmployee);
            return newEmployee;
        }

        [Fact]
        public async void ShouldCreateCompany()
        {
            var newEmployee = new Employee(0, "Novo Funcionário", 0, 1234.56, 0)
            {
                Company =
                    new Company(0, "Teste SA", 0, "1633112255")
                    {
                        Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                    },
                Position = new Position(0, "Programador")
            };

            var employeeService = GetEmployeeService(GetInMemoryEmployeeRepository());
            await employeeService.CreateAsync(newEmployee);
            var employeeCreated = await employeeService.GetByIdAsync(newEmployee.Id);
            Assert.NotNull(employeeCreated);
            Assert.Equal(0, employeeService.Validations().Messages.Count);
        }

        [Fact]
        public async void ShouldNotCreateEmployee()
        {
            var newEmployee = new Employee(0, "", 0, 1234.56, 0)
            {
                Company =
                    new Company(0, "Teste SA", 0, "1633112255")
                    {
                        Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                    },
                Position = new Position(0, "Programador")
            };

            var employeeService = GetEmployeeService(GetInMemoryEmployeeRepository());
            await employeeService.CreateAsync(newEmployee);
            Assert.True(employeeService.Validations().Messages.Count > 0 && newEmployee.Id == 0);
        }

        [Fact]
        public async void ShouldUpdateCompany()
        {
            var employeeService = GetEmployeeService(GetInMemoryEmployeeRepository());
            var employee = await CreateEmployee(employeeService);
            employee.Name = "Novo Nome";
            await employeeService.UpdateAsync(employee);
            var actualCompany = await employeeService.GetByIdAsync(employee.Id);
            Assert.Equal(employee.Name, actualCompany.Name);
            Assert.Equal(0, employeeService.Validations().Messages.Count);
        }

        [Fact]
        public async void ShouldNotUpdateCompany()
        {
            var employeeService = GetEmployeeService(GetInMemoryEmployeeRepository());
            var employee = await CreateEmployee(employeeService);
            employee.Name = "";
            await employeeService.UpdateAsync(employee);
            var actualEmployee = await employeeService.GetByIdAsync(employee.Id);
            Assert.NotEqual(employee.Name, actualEmployee.Name);
            Assert.True(employeeService.Validations().Messages.Count > 0);
        }

        [Fact]
        public async void ShouldDeleteCompany()
        {
            var employeeService = GetEmployeeService(GetInMemoryEmployeeRepository());
            var employee = await CreateEmployee(employeeService);
            var wasCreated = await employeeService.GetByIdAsync(employee.Id) != null;
            await employeeService.DeleteAsync(employee.Id);
            var employeeDeleted = await employeeService.GetByIdAsync(employee.Id) == null;
            Assert.True(wasCreated && employeeDeleted);
        }
    }
}
