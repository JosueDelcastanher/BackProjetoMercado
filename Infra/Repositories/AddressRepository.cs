using Domain.Entities;
using Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private MainContext _context;

        public AddressRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Create(Address address)
        {
            await _context.Address.AddAsync(address);
        }
        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _context.Address.AsNoTracking().ToListAsync();
        }

        public async Task<Address> GetById(int id)
        {
            return await _context.Address.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address> GetByRestaurantId(int restaurantId)
        {
            return await _context.Address.AsNoTracking().FirstOrDefaultAsync(x => x.RestaurantId == restaurantId);
        }

        public async Task<Address> GetByUserId(int userId)
        {
            return await _context.Address.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Address address)
        {
            _context.Update(address).State = EntityState.Modified;
        }
    }
}
