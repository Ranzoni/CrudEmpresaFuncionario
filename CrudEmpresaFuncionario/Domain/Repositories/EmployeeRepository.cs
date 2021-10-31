using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Domain.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CrudContext _context;

        public EmployeeRepository(CrudContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task CreateAsync(Employee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new ApplicationException("O funcionário para exclusão não existe");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Employee> Get()
        {
            return _context.Employees.Include(e => e.Position).AsNoTracking();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            return _context.Employees.AsNoTracking().Include(e => e.Position).Include(e => e.Company).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Employee entity)
        {
            if (entity.Id <= 0 || entity == null)
                throw new ApplicationException("O funcionário para alteração é inválido");

            if (!_context.Companies.Any(a => a.Id == entity.Id))
                throw new ApplicationException("O funcionário para alteração não existe");

            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
