using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Infra;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Domain.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly CrudContext _context;

        public PositionRepository(CrudContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Position>> GetAsync()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}
