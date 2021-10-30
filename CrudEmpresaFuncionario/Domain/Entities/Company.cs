using CrudEmpresaFuncionario.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Company : Notification
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [ForeignKey(nameof(Address))]
        public int IdAddress { get; set; }
        public Address Address { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public Company(int id, string name, int idAddress, string phoneNumber)
        {
            Id = id;
            Name = name;
            IdAddress = idAddress;
            PhoneNumber = phoneNumber;
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddNotification("O nome da empresa deve ser preenchido.");

            Address.Validate();
            if (!Address.IsValid)
                foreach (var notification in Address.Notifications.Messages)
                    AddNotification(notification.Message);

            if (!string.IsNullOrEmpty(PhoneNumber))
                if (PhoneNumber.Length > 11 || PhoneNumber.Length < 10)
                    AddNotification("O número de telefone é inválido. Ele deve conter o DDD mais o número.");
        }
    }
}
