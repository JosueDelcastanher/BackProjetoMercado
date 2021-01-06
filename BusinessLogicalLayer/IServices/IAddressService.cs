using BusinessLogicalLayer.Models.AddressModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IAddressService
    {
        Task<List<AddressResponseModel>> GetAll();
        Task<AddressResponseModel> GetById(int id);
        Task<AddressResponseModel> Create(int id, AddressRequestModel addressModel, bool IsRestaurant);
        Task<AddressResponseModel> UpdateAddressByUser(int userId, AddressUpdateModel addressModel);
        Task<AddressResponseModel> UpdateAddressByRestaurant(int restaurantId, AddressUpdateModel addressModel);
        Task<AddressResponseModel> GetByUserId(int userId);
        Task<AddressResponseModel> GetByRestaurantId(int restaurantId);
    }
}