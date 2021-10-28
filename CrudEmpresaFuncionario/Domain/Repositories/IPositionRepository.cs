using CrudEmpresaFuncionario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Domain.Repositories
{
    public interface IPositionRepository
    {
        Task<ICollection<Position>> GetAsync();
    }
}
