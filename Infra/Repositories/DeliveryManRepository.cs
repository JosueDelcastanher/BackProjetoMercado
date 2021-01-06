using Domain.Entities;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class DeliveryManRepository : IDeliveryManRepository
    {

        private MainContext _context;

        public DeliveryManRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Create(DeliveryMan entity)
        {
            await _context.DeliveryMan.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.DeliveryMan.FindAsync(id);
            entity.DeleteItem();
            _context.DeliveryMan.Update(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<DeliveryMan>> GetAll()
        {
            return await _context.DeliveryMan.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<DeliveryMan> GetById(int id)
        {
            return await _context.DeliveryMan.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(DeliveryMan entity)
        {
            _context.DeliveryMan.Update(entity);
        }
    }
}
