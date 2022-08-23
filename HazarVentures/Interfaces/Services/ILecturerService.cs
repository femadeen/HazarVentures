using HazarVentures.Models;
using HazarVentures.ViewModels.RequestModels;
using HazarVentures.ViewModels.ResponseModels;

namespace HazarVentures.Interfaces.Services
{
    public interface ILecturerService
    {
        public BaseResponse RegisterLecturer(CreateLecturerRequestModel model);
        public BaseResponse UpdateLecturer(int id, UpdateLecturerRequestModel model);
        public LecturerResponseModel DeleteLecturer(int id);
        public LecturerResponseModel GetLecturerById(int id);
        public LecturersResponseModel GetAllLecturer();
    }
}
