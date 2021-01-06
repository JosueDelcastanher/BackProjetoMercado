using BusinessLogicalLayer.Models.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAll();
        Task<UserResponseModel> GetById(int id);
        Task<UserResponseModel> Create(UserRequestModel userModel);
        Task<UserResponseModel> Update(int id, UserUpdateRequestModel userModel);
        Task<UserResponseModel> Delete(int id);
        Task<UserResponseModel> Login(UserLoginRequestModel userLoginRequestModel);
        Task<UserResponseModel> ChangePassword(int userId, UserPasswordRequestModel userPasswordRequestModel);

    }
}