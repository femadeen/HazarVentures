using HazarVentures.DTOs;
using HazarVentures.Models;
using System.Collections.Generic;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class UsersResponseModel : BaseResponse
    {
        public IEnumerable<UserDto> Data { get; set; } = new List<UserDto>();
    }
}
