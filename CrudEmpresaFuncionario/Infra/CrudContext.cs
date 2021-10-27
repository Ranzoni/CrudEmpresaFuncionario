using CrudEmpresaFuncionario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresaFuncionario.Infra
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
