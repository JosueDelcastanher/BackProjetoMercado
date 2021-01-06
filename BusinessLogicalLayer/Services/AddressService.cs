using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.AddressModel;
using Domain.Entities;
using Infra.IRepositories;
using Infra.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserRepository _userRepository;

        public AddressService(IAddressRepository addressRepository, IUserRepository userRepository, IRestaurantRepository restaurantRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<AddressResponseModel>> GetAll()
        {
            var adresses = await _addressRepository.GetAll();
            return adresses.Select(x => AddressMap.AddressToAddressResponse(x)).ToList();
        }

        public async Task<AddressResponseModel> GetById(int id)
        {
            var address = await _addressRepository.GetById(id);

            if (address == null)
                AddError("Endereco", "Não encontrado");

            HandleError();

            return AddressMap.AddressToAddressResponse(address);
        }

        public async Task<AddressResponseModel> GetByUserId(int userId)
        {
            var address = await _addressRepository.GetByUserId(userId);

            if (address == null)
                AddError("Endereco", "Não encontrado");

            HandleError();

            return AddressMap.AddressToAddressResponse(address);
        }

        public async Task<AddressResponseModel> GetByRestaurantId(int restaurantId)
        {
            var address = await _addressRepository.GetByRestaurantId(restaurantId);

            if (address == null)
                AddError("Endereco", "Não encontrado");

            HandleError();

            return AddressMap.AddressToAddressResponse(address);
        }

        public async Task<AddressResponseModel> UpdateAddressByUser(int userId, AddressUpdateModel addressModel)
        {
            var addressToUpdate = await _addressRepository.GetByUserId(userId);

            if (addressToUpdate == null)
                AddError("Endereço", "Não encontrado");

            addressToUpdate.Update(addressModel.State, addressModel.City, addressModel.Neighborhood, addressModel.Street, addressModel.Number);

            Validate(addressToUpdate);

            await _addressRepository.Update(addressToUpdate);
            await _addressRepository.Save();

            return AddressMap.AddressToAddressResponse(addressToUpdate);
        }

        public async Task<AddressResponseModel> UpdateAddressByRestaurant(int restaurantId, AddressUpdateModel addressModel)
        {
            var addressToUpdate = await _addressRepository.GetByRestaurantId(restaurantId);

            if (addressToUpdate == null)
                AddError("Endereço", "Não encontrado");

            addressToUpdate.Update(addressModel.State, addressModel.City, addressModel.Neighborhood, addressModel.Street, addressModel.Number);

            Validate(addressToUpdate);

            await _addressRepository.Update(addressToUpdate);
            await _addressRepository.Save();

            return AddressMap.AddressToAddressResponse(addressToUpdate);
        }

        public async Task<AddressResponseModel> Create(int id, AddressRequestModel addressModel, bool IsRestaurant)
        {
            var address = AddressMap.AddressRequestToAddress(addressModel);

            Validate(address);

            if (IsRestaurant)
            {
                address.SetRestaurant(id);

                var restaurant = await _restaurantRepository.GetById(id);

                if (restaurant == null || restaurant.AddressId != null)
                    AddError("Restaurante", "Invalido");
            }
            else
            {
                address.SetUser(id);

                var user = await _userRepository.GetById(id);

                if (user == null || user.AddressId != null)
                    AddError("Usuario", "Invalido");
            }

            HandleError();

            await _addressRepository.Create(address);
            await _addressRepository.Save();

            return AddressMap.AddressToAddressResponse(address);
        }
        public override void Validate(Address entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
