using HazarVentures.DTOs;
using HazarVentures.Models;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class StudentResponseModel : BaseResponse
    {
        public StudentDto Data { get; set; }
    }
}
