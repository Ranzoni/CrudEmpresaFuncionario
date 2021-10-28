using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Employee
    {
        [Key]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }
        [StringLength(200)]
        [JsonProperty("nome")]
        public string Name { get; set; }
        [ForeignKey(nameof(Position))]
        [System.Text.Json.Serialization.JsonIgnore]
        public int IdPosition { get; set; }
        [JsonProperty("cargo")]
        public Position Position { get; set; }
        public double Salary { get; set; }
        [ForeignKey(nameof(Company))]
        [System.Text.Json.Serialization.JsonIgnore]
        public int IdCompany { get; set; }
        [JsonProperty("empresa")]
        public Company Company { get; set; }

        public Employee(int id, string name, int idPosition, double salary, int idCompany)
        {
            Id = id;
            Name = name;
            IdPosition = idPosition;
            Salary = salary;
            IdCompany = idCompany;
        }
    }
}
