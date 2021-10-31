using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CrudContext _context;

        public UserRepository(CrudContext crudContext)
        {
            _context = crudContext;
        }

        public async Task CreateAsync(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new ApplicationException("O usuário para exclusão não existe");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public IQueryable<User> Get()
        {
            return _context.Users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByLogin(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName && u.Password == password);
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
