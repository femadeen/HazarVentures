using HazarVentures.DTOs;
using HazarVentures.Models;
using System.Collections.Generic;

namespace HazarVentures.ViewModels.ResponseModels
{
    public class StudentsResponseModel : BaseResponse
    {
        public IEnumerable<StudentDto> Data { get; set; } = new List<StudentDto>();
    }
}
