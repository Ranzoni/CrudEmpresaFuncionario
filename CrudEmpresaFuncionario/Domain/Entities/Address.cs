namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Address
    {
        public int Id { get; private set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Address2 { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
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
