using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Position
    {
        [Key]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; private set; }
        [JsonPropertyName("nome")]
        public string Name { get; private set; }

        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
