using CrudEmpresaFuncionario.Domain.Entities;
using Xunit;

namespace CrudEmpresaFuncionario.Tests.Domain.Entities
{
    public class EmployeeTest
    {
        [Fact]
        public void ShouldReturnSuccessWhenEmployeeIsValid()
        {
            var employee = new Employee(1, "Batman", 1, 1234.56, 1)
            {
                Position = new Position(1, "Vigilante"),
                Company = new Company(1, "Wayne Enterprise", 1, "1633115588")
            };
            employee.Validate();
            Assert.True(employee.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenNameIsEmpty(string name)
        {
            var employee = new Employee(1, name, 1, 1234.56, 1)
            {
                Position = new Position(1, "Vigilante"),
                Company = new Company(1, "Wayne Enterprise", 1, "1633115588")
            };
            employee.Validate();
            Assert.True(!employee.IsValid);
        }

        [Fact]
        public void ShouldReturnFailWhenPositionIsEmpty()
        {
            var employee = new Employee(1, "Batman", 0, 1234.56, 1)
            {
                Company = new Company(1, "Wayne Enterprise", 1, "1633115588")
            };
            employee.Validate();
            Assert.True(!employee.IsValid);
        }

        [Fact]
        public void ShouldReturnFailWhenCompanyIsEmpty()
        {
            var employee = new Employee(1, "Batman", 1, 1234.56, 0)
            {
                Position = new Position(1, "Vigilante")
            };
            employee.Validate();
            Assert.True(!employee.IsValid);
        }
    }
}
