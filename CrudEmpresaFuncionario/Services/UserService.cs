using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task<User> GetByLogin(string userName, string password)
        {
            return await _userRepository.GetByLogin(userName, password);
        }
    }
}
