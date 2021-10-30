using CrudEmpresaFuncionario.Shared;
using System.ComponentModel.DataAnnotations;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Address : Notification
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Street { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
        [StringLength(50)]
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

        public override void Validate()
        {

            if (string.IsNullOrEmpty(Street))
                AddNotification("A rua deve ser preenchida.");

            if (string.IsNullOrEmpty(Number))
                AddNotification("O número do endereço deve ser preenchido.");

            if (string.IsNullOrEmpty(Neighborhood))
                AddNotification("O bairro deve ser preenchido.");

            if (string.IsNullOrEmpty(City))
                AddNotification("A cidade deve ser preenchida.");

            if (string.IsNullOrEmpty(State))
                AddNotification("O estado do endereço deve ser preenchido.");

            if (string.IsNullOrEmpty(ZipCode))
                AddNotification("O CEP deve ser preenchido.");
        }
    }
}
