using Domain;
using Infra.IRepositories.IGenericRepository;
using System.Threading.Tasks;

namespace Infra.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> EmailExist(User user);
        Task<User> Login(string email, string password);
    }
}
