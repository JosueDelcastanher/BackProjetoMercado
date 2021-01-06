using Domain.Entities;
using Infra.IRepositories.IGenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.IRepositories
{
    public interface ICommentRestaurantRepository : IGenericRepository<CommentRestaurant>
    {
        Task<ICollection<CommentRestaurant>> GetByRestaurantId(int restaurantId);
    }
}
