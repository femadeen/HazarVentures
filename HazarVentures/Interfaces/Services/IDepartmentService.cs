using HazarVentures.Models;
using HazarVentures.ViewModels.RequestModels;
using HazarVentures.ViewModels.ResponseModels;

namespace HazarVentures.Interfaces.Services
{
    public interface IDepartmentService
    {
        public BaseResponse AddDepartment(CreateDepartmentRequestModel model);
        public BaseResponse UpdateDepartment(int id, UpdateDepartmentRequestModel model);
        public DepartmentResponseModel DeleteDepartment(int id);
        public DepartmentResponseModel GetDepartmentById(int id);
        public DepartmentsResponseModel GetAllDepartments();

    }
}
