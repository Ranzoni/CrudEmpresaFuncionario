using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresaFuncionario.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CrudContext _context;

        public CompanyRepository(CrudContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Company entity)
        {
            _context.Companies.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
                throw new ApplicationException("A empresa para exclusão não existe");

            var address = await _context.Addresses.FindAsync(company.IdAddress);
            if (address != null)
                _context.Addresses.Remove(address);

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Company> Get()
        {
            return _context.Companies.Include(c => c.Address).AsNoTracking();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies.AsNoTracking().Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Company entity)
        {
            if (entity.Id <= 0 || entity == null)
                throw new ApplicationException("A empresa para alteração é inválida");

            if (!_context.Companies.Any(a => a.Id == entity.Id))
                throw new ApplicationException("A empresa para alteração é inexistente");

            _context.Companies.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
