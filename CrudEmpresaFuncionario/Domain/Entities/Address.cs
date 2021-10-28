using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [JsonProperty("logradouro")]
        public string Street { get; set; }
        [StringLength(10)]
        [JsonProperty("numero")]
        public string Number { get; set; }
        [JsonProperty("complemento")]
        public string Address2 { get; set; }
        [StringLength(200)]
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }
        [StringLength(200)]
        [JsonProperty("cidade")]
        public string City { get; set; }
        [StringLength(200)]
        [JsonProperty("estado")]
        public string State { get; set; }
        [StringLength(200)]
        [JsonProperty("pais")]
        public string Country { get; set; }
        [StringLength(20)]
        [JsonProperty("cep")]
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
