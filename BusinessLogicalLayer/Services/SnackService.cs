using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.SnackModel;
using BusinessLogicalLayer.Utils;
using Domain.Entities;
using Infra.IRepositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class SnackService : BaseService<Snack>, ISnackService
    {

        private readonly ISnackRepository _snackRepository;
        private readonly IRestaurantRepository _restaurantRepository;


        public SnackService(ISnackRepository snackRepository, IRestaurantRepository restaurantRepository)
        {
            _snackRepository = snackRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<SnackResponseModel> Create(int restaurantId, SnackRequestModel model, IFormFile image)
        {
            var snack = SnackMap.SnackRequestToSnack(model);
            snack.SetRestaurantId(restaurantId);

            Validate(snack);

            var restaurant = await _restaurantRepository.GetById(restaurantId);

            if (restaurant == null)
                AddError("Restaurante", "Invalido");

            var path = ImageService.InsertImageAndReturnPath(image);

            snack.SetImagePath(path);

            HandleError();

            await _snackRepository.Create(snack);
            await _snackRepository.Save();

            return SnackMap.SnackToSnackResponseModel(snack);
        }

        public async Task<SnackResponseModel> Delete(int restaurantId, int id)
        {
            var snack = await _snackRepository.GetById(id);

            if (snack == null || snack.RestaurantId != restaurantId)
                AddError("Lanche", "Invalido");

            HandleError();

            await _snackRepository.Delete(id);
            await _snackRepository.Save();

            return SnackMap.SnackToSnackResponseModel(snack);
        }

        public async Task<SnackResponseModel> GetById(int restaurantId, int id)
        {
            var snack = await _snackRepository.GetById(id);

            if (snack == null || snack.RestaurantId != restaurantId)
                AddError("Lanche", "Invalido");

            HandleError();

            return SnackMap.SnackToSnackResponseModel(snack);
        }

        public async Task<ICollection<SnackResponseModel>> GetByRestaurantId(int restaurantId)
        {
            var snacks = await _snackRepository.GetByRestaurantId(restaurantId);
            return snacks.Select(x => SnackMap.SnackToSnackResponseModel(x)).ToList();
        }

        public async Task<SnackResponseModel> Update(int restaurantId, int id, SnackUpdateModel model)
        {
            ValidateId(restaurantId);
            ValidateId(id);

            HandleError();

            var snack = await _snackRepository.GetById(id);

            if (snack == null || snack.RestaurantId != restaurantId)
                AddError("Lanche", "Invalido");

            HandleError();

            snack.Update(model.Name, model.Description, model.Price);

            Validate(snack);

            await _snackRepository.Update(snack);
            await _snackRepository.Save();

            return SnackMap.SnackToSnackResponseModel(snack);
        }

        public override void Validate(Snack entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
