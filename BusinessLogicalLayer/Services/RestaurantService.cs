using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.RestaurantModel;
using BusinessLogicalLayer.Utils;
using Domain.Entities;
using Infra.IRepositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class RestaurantService : BaseService<Restaurant>, IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<RestaurantResponseModel> ChangePassword(int restaurantId, RestaurantPasswordRequestModel restaurantPasswordModel)
        {
            var restaurant = await _restaurantRepository.GetById(restaurantId);

            if (restaurant == null)
                AddError("Usuario", "Não encontrado");

            var IsEqual = HashService.CompareHash(restaurantPasswordModel.Password, restaurant.Password);

            if (IsEqual)
                AddError("Senha", "Senha invalida!");

            HandleError();

            restaurant.ChangePassword(restaurantPasswordModel.Password);

            Validate(restaurant);

            restaurant.HashPassword();

            await _restaurantRepository.Update(restaurant);
            await _restaurantRepository.Save();

            return RestaurantMap.RestaurantToRestaurantResponse(restaurant);
        }

        public async Task<RestaurantResponseModel> Create(RestaurantRequestModel restaurantModel, IFormFile image)
        {
            var restaurant = RestaurantMap.RestaurantRequestToRestaurant(restaurantModel);

            Validate(restaurant);
            await CnpjExist(restaurant);

            restaurant.HashPassword();

            var path = ImageService.InsertImageAndReturnPath(image);

            restaurant.SetImagePath(path);

            HandleError();

            await _restaurantRepository.Create(restaurant);
            await _restaurantRepository.Save();

            return RestaurantMap.RestaurantToRestaurantResponse(restaurant);
        }

        public async Task<RestaurantResponseModel> Delete(int id)
        {
            ValidateId(id);

            HandleError();

            var restaurant = await _restaurantRepository.GetById(id);

            if (restaurant == null)
                AddError("Restaurante", "Não encontrado");

            HandleError();

            await _restaurantRepository.Delete(id);
            await _restaurantRepository.Save();

            return RestaurantMap.RestaurantToRestaurantResponse(restaurant);
        }

        public async Task<ICollection<RestaurantResponseModel>> GetAll()
        {
            var restaurants = await _restaurantRepository.GetAll();
            return restaurants.Select(restaurant => RestaurantMap.RestaurantToRestaurantResponse(restaurant)).ToList();
        }

        public async Task<RestaurantResponseModel> GetById(int id)
        {
            ValidateId(id);

            HandleError();

            var restaurant = await _restaurantRepository.GetById(id);

            if (restaurant == null)
                AddError("Restaurante", "Não encontrado");

            HandleError();

            return RestaurantMap.RestaurantToRestaurantResponse(restaurant);
        }

        public async Task<RestaurantResponseModel> Login(RestaurantLoginRequestModel restaurantLoginModel)
        {
            var passwordHash = HashService.HashString(restaurantLoginModel.Password);
            var restaurant = await _restaurantRepository.Login(restaurantLoginModel.Email, passwordHash);

            if (restaurant == null)
                AddError("Email ou senha", "Invalido");

            HandleError();

            return RestaurantMap.RestaurantToRestaurantResponse(restaurant);
        }

        public async Task<RestaurantResponseModel> Update(int id, RestaurantUpdateRequestModel restaurantUpdateModel)
        {
            var restaurantToUpdate = await _restaurantRepository.GetById(id);

            if (restaurantToUpdate == null)
                AddError("Restaurante", "Não encontrado");

            HandleError();

            restaurantToUpdate.Update(restaurantUpdateModel.Name, restaurantUpdateModel.Email);

            await _restaurantRepository.Update(restaurantToUpdate);
            await _restaurantRepository.Save();

            return RestaurantMap.RestaurantToRestaurantResponse(restaurantToUpdate);
        }

        private async Task CnpjExist(Restaurant entity)
        {
            var cnpjExist = await _restaurantRepository.CnpjExist(entity);

            if (cnpjExist)
                AddError("CNPJ", "Ja cadastrado");

            HandleError();
        }

        public override void Validate(Restaurant entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
