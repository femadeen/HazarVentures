using HazarVentures.Models;
using HazarVentures.ViewModels.RequestModels;
using HazarVentures.ViewModels.ResponseModels;

namespace HazarVentures.Interfaces.Services
{
    public interface IStudentService
    {
        public BaseResponse AddStudent(CreateStudentRequestModel model);
        public BaseResponse UpdateStudent(int id, UpdateStudentRequestModel model);
        public DepartmentResponseModel DeleteStudent(int id);
        public StudentResponseModel GetStudentById(int id);
        public StudentsResponseModel GetAllStudents();
    }
}
