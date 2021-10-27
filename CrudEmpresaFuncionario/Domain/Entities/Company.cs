using System.ComponentModel.DataAnnotations;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Company
    {
        public int Id { get; private set; }
        [StringLength(200)]
        public string Name { get; set; }
        public int IdAddress { get; private set; }
        public Address Address { get; private set; }
        public string PhoneNumber { get; set; }

        public Company(int id, string name, int idAddress, string phoneNumber)
        {
            Id = id;
            Name = name;
            IdAddress = idAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
