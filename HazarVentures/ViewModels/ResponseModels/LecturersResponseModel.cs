using HazarVentures.DTOs;
using HazarVentures.Models;
using System.Collections.Generic;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class LecturersResponseModel : BaseResponse
    {
        public IEnumerable<LecturerDto> Data { get; set; } = new List<LecturerDto>();
    }
}
