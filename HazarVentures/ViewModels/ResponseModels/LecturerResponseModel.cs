using HazarVentures.DTOs;
using HazarVentures.Models;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class LecturerResponseModel : BaseResponse
    {
        public LecturerDto Data { get; set; }
    }
}
