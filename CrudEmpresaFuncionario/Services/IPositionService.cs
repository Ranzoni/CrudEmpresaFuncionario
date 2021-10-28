using CrudEmpresaFuncionario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public interface IPositionService
    {
        Task<List<Position>> GetAsync();
    }
}
