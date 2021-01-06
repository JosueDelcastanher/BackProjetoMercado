using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.IRepositories.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task Save();
    }
}
