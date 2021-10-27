using System.ComponentModel.DataAnnotations;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        [StringLength(200)]
        public string Name { get; set; }
        public int IdPosition { get; private set; }
        public Position Position { get; private set; }
        public double Salary { get; set; }

        public Employee(int id, string name, int idPosition, Position position, double salary)
        {
            Id = id;
            Name = name;
            IdPosition = idPosition;
            Position = position;
            Salary = salary;
        }
    }
}
