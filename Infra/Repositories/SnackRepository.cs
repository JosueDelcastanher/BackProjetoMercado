using Domain.Entities;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class SnackRepository : ISnackRepository
    {

        private MainContext _context;

        public SnackRepository(MainContext context)
        {
            _context = context;
        }
        public async Task Create(Snack snack)
        {
            await _context.Snack.AddAsync(snack);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Snack.FindAsync(id);
            entity.DeleteItem();
            _context.Snack.Update(entity).State = EntityState.Modified;
        }

        public async Task<Snack> GetById(int id)
        {
            return await _context.Snack.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<ICollection<Snack>> GetByRestaurantId(int restaurantId)
        {
            return await _context.Snack.AsNoTracking().Where(x => x.RestaurantId == restaurantId && !x.Deleted).ToListAsync();
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task Update(Snack snack)
        {
            _context.Snack.Update(snack);
        }
    }
}
