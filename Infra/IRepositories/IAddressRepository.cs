using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories.IRepositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAll();
        Task<Address> GetById(int id);
        Task Create(Address entity);
        Task Update(Address entity);
        Task<Address> GetByUserId(int userId);
        Task<Address> GetByRestaurantId(int restaurantId);
        Task Save();

    }
}
