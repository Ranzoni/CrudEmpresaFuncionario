using System.ComponentModel.DataAnnotations;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
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
        [StringLength(20)]
        public string ZipCode { get; set; }

        public Address(string street, string number, string address2, string neighborhood, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            Address2 = address2;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
