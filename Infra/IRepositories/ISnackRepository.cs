using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.IRepositories
{
    public interface ISnackRepository
    {
        Task<ICollection<Snack>> GetByRestaurantId(int restaurantId);
        Task Create(Snack snack);
        Task<Snack> GetById(int id);
        Task Update(Snack snack);
        Task Delete(int id);
        Task Save();
    }
}
