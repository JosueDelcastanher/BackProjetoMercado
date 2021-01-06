using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.CommentRestaurantModel;
using Domain.Entities;
using Infra.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class CommentRestaurantService : BaseService<CommentRestaurant>, ICommentRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICommentRestaurantRepository _commentRestaurantRepository;
        private readonly IUserRepository _userRepository;

        public CommentRestaurantService(IRestaurantRepository restaurantRepository, ICommentRestaurantRepository commentRestaurantRepository, IUserRepository userRepository)
        {
            _restaurantRepository = restaurantRepository;
            _commentRestaurantRepository = commentRestaurantRepository;
            _userRepository = userRepository;
        }

        public async Task<CommentRestaurantResponseModel> Create(int restaurantId, CommentRestaurantRequestModel commentModel)
        {
            var comment = CommentRestaurantMap.CommentRestaurantRequestToCommentRestaurant(commentModel);
            comment.SetRestaurantId(restaurantId);

            Validate(comment);
            await ValidateRestaurantExist(comment.RestaurantId);
            await ValidateUserExist(comment.UserId);

            HandleError();

            await _commentRestaurantRepository.Create(comment);
            await _commentRestaurantRepository.Save();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment);
        }

        public async Task<CommentRestaurantResponseModel> Delete(int restaurantId, int id)
        {
            var comment = await _commentRestaurantRepository.GetById(id);

            if (comment == null || comment.RestaurantId != restaurantId)
                AddError("Comentario", "Não encontrado");

            HandleError();

            await _commentRestaurantRepository.Delete(id);
            await _commentRestaurantRepository.Save();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment);
        }

        public async Task<List<CommentRestaurantResponseModel>> GetAll()
        {
            var comments = await _commentRestaurantRepository.GetAll();
            return comments.Select(comment => CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment)).ToList();
        }

        public async Task<CommentRestaurantResponseModel> GetById(int restaurantId, int id)
        {
            var comment = await _commentRestaurantRepository.GetById(id);

            if (comment == null || comment.RestaurantId != restaurantId)
                AddError("Comentario", "Não encontrado");

            HandleError();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment);
        }

        public async Task<ICollection<CommentRestaurantResponseModel>> GetByRestaurantId(int restaurantId)
        {
            var restaurantExist = await _restaurantRepository.GetById(restaurantId);

            if (restaurantExist == null)
                AddError("Restaurante", "Não encontrado");

            var comments = await _commentRestaurantRepository.GetByRestaurantId(restaurantId);
            return comments.Select(comment => CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(comment)).ToList();
        }

        public async Task<CommentRestaurantResponseModel> Update(int restaurantId, CommentUpdateModel commentModel, int id)
        {
            var commentToUpdate = await _commentRestaurantRepository.GetById(id);

            if (commentToUpdate == null || commentToUpdate.RestaurantId != restaurantId)
                AddError("Comentario", "Não encontrado");

            HandleError();

            commentToUpdate.Update(commentModel.Commentary, commentModel.IsGood);

            HandleError();

            await _commentRestaurantRepository.Update(commentToUpdate);
            await _commentRestaurantRepository.Save();

            return CommentRestaurantMap.CommentRestaurantToCommentRestaurantResponse(commentToUpdate);

        }

        private async Task ValidateRestaurantExist(int restaurantId)
        {
            var restaurantExist = await _restaurantRepository.GetById(restaurantId);

            if (restaurantExist == null)
                AddError("Restaurante", "Não encontrado");
        }

        private async Task ValidateUserExist(int userId)
        {
            var userExist = await _userRepository.GetById(userId);

            if (userExist == null)
                AddError("Usuario", "Não encontrado");
        }

        public override void Validate(CommentRestaurant entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
