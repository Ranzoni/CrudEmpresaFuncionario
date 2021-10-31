using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using CrudEmpresaFuncionario.Infra;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CrudEmpresaFuncionario.Tests.Domain.Repositories
{
    public class EmployeeRepositoryTest
    {
        private static IEmployeeRepository GetInMemoryRepositoryRepository()
        {
            var builder = new DbContextOptionsBuilder<CrudContext>();
            builder.UseInMemoryDatabase("crudempresafuncionario");
            var options = builder.Options;
            var crudContext = new CrudContext(options);
            crudContext.Database.EnsureDeleted();
            crudContext.Database.EnsureCreated();
            return new EmployeeRepository(crudContext);
        }

        private static async Task<Employee> CreateEmployee(IEmployeeRepository employeeRepository)
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

            await employeeRepository.CreateAsync(newEmployee);
            return newEmployee;
        }

        private static async Task<Employee> CreateEmployee(IEmployeeRepository employeeRepository, Employee newEmployee)
        {
            await employeeRepository.CreateAsync(newEmployee);
            return newEmployee;
        }

        [Fact]
        public async void ShouldCreateEmployee()
        {
            var employeeRepository = GetInMemoryRepositoryRepository();
            var newEmployee = await CreateEmployee(employeeRepository);
            var employee = await employeeRepository.GetByIdAsync(newEmployee.Id);
            Assert.NotNull(employee);
        }

        [Fact]
        public async void ShouldUpdateEmployee()
        {
            var employeeRepository = GetInMemoryRepositoryRepository();
            var employee = await CreateEmployee(employeeRepository);
            employee.Name = "Novo Nome";
            await employeeRepository.UpdateAsync(employee);
            var actualEmployee = await employeeRepository.GetByIdAsync(employee.Id);
            Assert.Equal(employee.Name, actualEmployee.Name);
        }

        [Fact]
        public async void ShouldDeleteEmployee()
        {
            var employeeRepository = GetInMemoryRepositoryRepository();
            var employee = await CreateEmployee(employeeRepository);
            var wasCreated = await employeeRepository.GetByIdAsync(employee.Id) != null;
            await employeeRepository.DeleteAsync(employee.Id);
            var employeeDeleted = await employeeRepository.GetByIdAsync(employee.Id) == null;
            Assert.True(wasCreated && employeeDeleted);
        }

        [Fact]
        public async void ShouldGetAllEmployees()
        {
            var employeesToCreate = new List<Employee>
            {
                new Employee(0, "Novo Funcionário 1", 0, 1234.56, 0)
                {
                    Company =
                        new Company(0, "Teste SA", 0, "1633112255")
                        {
                            Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                        },
                    Position = new Position(0, "Programador")
                },
                new Employee(0, "Novo Funcionário 2", 1, 1234.56, 1)
                {
                    Company =
                        new Company(0, "Teste SA 2", 0, "1633112255")
                        {
                            Address = new Address("Travessos 2", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                        },
                    Position = new Position(0, "Tester")
                },
                new Employee(0, "Novo Funcionário 3", 1, 1234.56, 1)
                {
                    Company =
                        new Company(0, "Teste SA 3", 0, "1633112255")
                        {
                            Address = new Address("Travessos 3", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
                        },
                    Position = new Position(0, "RH")
                }
            };
            var employeeRepository = GetInMemoryRepositoryRepository();

            foreach (var employee in employeesToCreate)
                await CreateEmployee(employeeRepository, employee);

            var employees = await employeeRepository.Get().ToListAsync();
            var idsEmployeeReturned = employees.Select(c => c.Id);
            var idsEmployeeCreated = employeesToCreate.Select(c => c.Id).ToList();
            var employeesWereReturned = idsEmployeeReturned.Intersect(idsEmployeeCreated).Count() == idsEmployeeCreated.Count();
            Assert.True(employeesWereReturned);
        }
    }
}
