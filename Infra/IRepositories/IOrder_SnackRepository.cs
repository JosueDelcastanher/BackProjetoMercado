using Domain.Entities;
using System.Threading.Tasks;

namespace Infra.IRepositories
{
    public interface IOrder_SnackRepository
    {
        Task Create(Order_Snack order_Snack);
        Task Save();
    }
}
