using Domain.Entities;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CommentRestaurantRepository : ICommentRestaurantRepository
    {

        private MainContext _context;

        public CommentRestaurantRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Create(CommentRestaurant entity)
        {
            await _context.CommentRestaurant.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.CommentRestaurant.FindAsync(id);
            entity.DeleteItem();
            _context.CommentRestaurant.Update(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<CommentRestaurant>> GetAll()
        {
            return await _context.CommentRestaurant.AsNoTracking().Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<CommentRestaurant> GetById(int id)
        {
            return await _context.CommentRestaurant.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<ICollection<CommentRestaurant>> GetByRestaurantId(int restaurantId)
        {
            return await _context.CommentRestaurant.Where(x => !x.Deleted && x.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(CommentRestaurant entity)
        {
            _context.CommentRestaurant.Update(entity);
        }
    }
}
