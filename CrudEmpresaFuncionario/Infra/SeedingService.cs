using CrudEmpresaFuncionario.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CrudEmpresaFuncionario.Infra
{
    public class SeedingService
    {
        private readonly CrudContext _context;

        public SeedingService(CrudContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Positions.Any())
            {
                var positions = new List<Position>
                {
                    new Position(1, "Programador"),
                    new Position(2, "Designer"),
                    new Position(3, "Administração"),
                    new Position(4, "RH")
                };
                _context.Positions.AddRange(positions);
                _context.SaveChanges();
            }

            if (!_context.Users.Any())
            {
                var user = new User("Admin", "@AdminFunc1");
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }
    }
}
