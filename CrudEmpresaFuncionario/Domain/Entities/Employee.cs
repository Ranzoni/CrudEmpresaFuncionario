using CrudEmpresaFuncionario.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Employee : Notification
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [ForeignKey(nameof(Position))]
        public int IdPosition { get; set; }
        public Position Position { get; set; }
        public double Salary { get; set; }
        [ForeignKey(nameof(Company))]
        public int IdCompany { get; set; }
        public Company Company { get; set; }

        public Employee(int id, string name, int idPosition, double salary, int idCompany)
        {
            Id = id;
            Name = name;
            IdPosition = idPosition;
            Salary = salary;
            IdCompany = idCompany;
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddNotification("O nome do funcionário deve ser preenchido.");

            if (IdPosition <= 0 && Position == null)
                AddNotification("O cargo do funcionário deve ser informado.");

            if (IdCompany <= 0 && Company == null)
                AddNotification("Deve ser informada a empresa a que o funcionário pertence.");
        }
    }
}
