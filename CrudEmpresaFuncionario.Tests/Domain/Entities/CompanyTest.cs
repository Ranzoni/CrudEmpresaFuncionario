using CrudEmpresaFuncionario.Domain.Entities;
using Xunit;

namespace CrudEmpresaFuncionario.Tests.Domain.Entities
{
    public class CompanyTest
    {
        [Fact]
        public void ShouldReturnSuccessWhenCompanyIsValid()
        {
            var company = new Company(1, "Teste SA", 1, "1633112255")
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };
            company.Validate();
            Assert.True(company.IsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("1633112255")]
        [InlineData("16999917000")]
        public void ShouldReturnSuccessWhenPhoneNumberIsValid(string phoneNumber)
        {
            var company = new Company(1, "Teste SA", 1, phoneNumber)
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };
            company.Validate();
            Assert.True(company.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("33112255")]
        [InlineData("999917000")]
        [InlineData("1161")]
        public void ShouldReturnFailWhenPhoneNumberIsInvalid(string phoneNumber)
        {
            var company = new Company(1, "Teste SA", 1, phoneNumber)
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };
            company.Validate();
            Assert.True(!company.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenNameIsEmpty(string name)
        {
            var company = new Company(1, name, 1, "16999336677")
            {
                Address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };
            company.Validate();
            Assert.True(!company.IsValid);
        }

        [Fact]
        public void ShouldReturnFailWhenAddressIsEmpty()
        {
            var company = new Company(1, "Teste SA", 0, "16999336677");
            company.Validate();
            Assert.True(!company.IsValid);
        }

        [Fact]
        public void ShouldReturnFailWhenAddressIsInvalid()
        {
            var company = new Company(1, "Teste SA", 0, "16999336677")
            {
                Address = new Address("", "11", null, "Liberdade", "Gotham City", "SP", "14303111")
            };
            company.Validate();
            Assert.True(!company.IsValid);
        }
    }
}
