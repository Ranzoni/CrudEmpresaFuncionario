using System.ComponentModel.DataAnnotations;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Address
    {
        public int Id { get; private set; }
        [StringLength(200)]
        public string Street { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
        public string Address2 { get; set; }
        [StringLength(200)]
        public string Neighborhood { get; set; }
        [StringLength(200)]
        public string City { get; set; }
        [StringLength(200)]
        public string State { get; set; }
        [StringLength(200)]
        public string Country { get; set; }
        [StringLength(20)]
        public string ZipCode { get; set; }

        public Address(string street, string number, string address2, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Address2 = address2;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
