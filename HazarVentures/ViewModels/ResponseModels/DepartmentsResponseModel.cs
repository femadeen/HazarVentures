using HazarVentures.DTOs;
using HazarVentures.Models;
using System.Collections.Generic;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class DepartmentsResponseModel : BaseResponse
    {
        public IEnumerable<DepartmentDto> Data { get; set; } = new List<DepartmentDto>();
    }
}
