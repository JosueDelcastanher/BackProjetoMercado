using Domain.Entities;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private MainContext _context;

        public RestaurantRepository(MainContext context)
        {
            _context = context;
        }
        public async Task<bool> CnpjExist(Restaurant restaurant)
        {
            return await _context.Restaurant.AnyAsync(x => x.CNPJ == restaurant.CNPJ && x.Id != restaurant.Id && !x.Deleted);
        }

        public async Task Create(Restaurant entity)
        {
            await _context.Restaurant.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Restaurant.FindAsync(id);
            entity.DeleteItem();
            _context.Restaurant.Update(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await _context.Restaurant.AsNoTracking().Include(x => x.Address).Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Restaurant> GetById(int id)
        {
            return await _context.Restaurant.AsNoTracking().Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<Restaurant> Login(string email, string password)
        {
            return await _context.Restaurant.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Restaurant entity)
        {
            _context.Restaurant.Update(entity).State = EntityState.Modified;
        }
    }
}
