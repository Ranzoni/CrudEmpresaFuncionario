using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Username { get; set; }
        [StringLength(15)]
        public string Password { get; set; }
        [ForeignKey(nameof(Company))]
        public int IdCompany { get; set; }
        public Company Company { get; set; }

        public User(string username, string password, int idCompany)
        {
            Username = username;
            Password = password;
            IdCompany = idCompany;
        }
    }
}
