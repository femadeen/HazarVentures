using HazarVentures.DTOs;
using HazarVentures.Models;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class DepartmentResponseModel : BaseResponse
    { 
       public DepartmentDto Data { get; set; } 
    }
}
