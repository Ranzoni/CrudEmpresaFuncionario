using CrudEmpresaFuncionario.Domain.Entities;
using Xunit;

namespace CrudEmpresaFuncionario.Tests.Domain.Entities
{
    public class AddressTest
    {
        [Fact]
        public void ShouldReturnSuccessWhenAddressHasNotAddress2()
        {
            var address = new Address("Travessos", "11", null, "Liberdade", "Gotham City", "SP", "14303111");
            address.Validate();
            Assert.True(address.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenAddressHasAddress2()
        {
            var address = new Address("Travessos", "11", "apartamento nº 01", "Liberdade", "Gotham City", "SP", "14303111");
            address.Validate();
            Assert.True(address.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenStreetIsEmpty(string street)
        {
            var address = new Address(street, "11", "apartamento nº 01", "Liberdade", "Gotham City", "SP", "14303111");
            address.Validate();
            Assert.True(!address.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenNumberIsEmpty(string number)
        {
            var address = new Address("Travessos", number, "apartamento nº 01", "Liberdade", "Gotham City", "SP", "14303111");
            address.Validate();
            Assert.True(!address.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenNeighborhoodIsEmpty(string neighborhood)
        {
            var address = new Address("neighborhood", "11", "apartamento nº 01", neighborhood, "Gotham City", "SP", "14303111");
            address.Validate();
            Assert.True(!address.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenCityIsEmpty(string city)
        {
            var address = new Address("Travessos", "11", "apartamento nº 01", "Liberdade", city, "SP", "14303111");
            address.Validate();
            Assert.True(!address.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenStateIsEmpty(string state)
        {
            var address = new Address("Travessos", "11", "apartamento nº 01", "Liberdade", "Gotham City", state, "14303111");
            address.Validate();
            Assert.True(!address.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFailWhenZipCodeIsEmpty(string zipCode)
        {
            var address = new Address("Travessos", "11", "apartamento nº 01", "Liberdade", "Gotham City", "SP", zipCode);
            address.Validate();
            Assert.True(!address.IsValid);
        }
    }
}
