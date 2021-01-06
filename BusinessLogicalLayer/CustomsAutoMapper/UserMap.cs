using BusinessLogicalLayer.Models.UserModel;
using Domain;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class UserMap
    {
        public static User UserRequestToUser(UserRequestModel userRequestModel)
        {
            return Map.ChangeValues<UserRequestModel, User>(userRequestModel);
        }

        public static UserResponseModel UserToUserResponse(User user)
        {
            return Map.ChangeValues<User, UserResponseModel>(user);
        }
    }
}
