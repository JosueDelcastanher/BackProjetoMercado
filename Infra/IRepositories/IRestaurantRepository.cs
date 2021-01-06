using Domain.Entities;
using Infra.IRepositories.IGenericRepository;
using System.Threading.Tasks;

namespace Infra.IRepositories
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        Task<bool> CnpjExist(Restaurant restaurant);
        Task<Restaurant> Login(string email, string password);
    }
}
