using System.ComponentModel.DataAnnotations;

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

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
