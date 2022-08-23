using HazarVentures.DTOs;
using HazarVentures.Models;
using System.Collections.Generic;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class RolesResponseModel : BaseResponse
    {
        public IEnumerable<RoleDto> Data {get; set;} = new List<RoleDto>();
    }
}
