using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<List<Position>> GetAsync()
        {
            return (await _positionRepository.GetAsync()).ToList();
        }
    }
}
