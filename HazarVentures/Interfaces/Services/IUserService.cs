using HazarVentures.ViewModels.RequestModels;
using HazarVentures.ViewModels.ResponseModels;

namespace HazarVentures.Interfaces.Services
{
    public interface IUserService
    {
        public UserResponseModel Login(LoginRequestModel model);
        public UsersResponseModel GetAllUSers();
        public UserResponseModel GetUserById(int id);
    }
}
