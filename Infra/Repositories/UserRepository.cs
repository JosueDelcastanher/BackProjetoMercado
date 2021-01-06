using Domain;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {

        private MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Create(User entity)
        {
            await _context.User.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.User.FindAsync(id);
            entity.DeleteItem();
            _context.User.Update(entity).State = EntityState.Modified;
        }

        public async Task<bool> EmailExist(User user)
        {
            return await _context.User.AnyAsync(x => x.Email == user.Email && x.Id != user.Id && !x.Deleted);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.AsNoTracking().Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<User> Login(string email, string password)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _context.User.Update(entity).State = EntityState.Modified;
        }
    }
}
