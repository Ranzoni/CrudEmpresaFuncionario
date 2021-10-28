using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Shared
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> Get();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
