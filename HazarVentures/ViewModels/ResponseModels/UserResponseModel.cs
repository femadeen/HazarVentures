using HazarVentures.DTOs;
using HazarVentures.Models;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class UserResponseModel : BaseResponse
    {
        public UserDto Data { get; set; }
    }
}
