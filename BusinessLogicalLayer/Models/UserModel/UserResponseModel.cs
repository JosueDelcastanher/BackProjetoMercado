using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.UserModel
{
    public class UserResponseModel : UserRequestModel, IResponseModel
    {
        public int Id { get; set; }
    }
}
