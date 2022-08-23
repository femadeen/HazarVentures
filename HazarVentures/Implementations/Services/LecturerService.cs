using HazarVentures.DTOs;
using HazarVentures.Entities;
using HazarVentures.Interfaces.Respositories;
using HazarVentures.Interfaces.Services;
using HazarVentures.Models;
using HazarVentures.ViewModels.RequestModels;
using HazarVentures.ViewModels.ResponseModels;
using System;
using System.Linq;

namespace HazarVentures.Implementations.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public LecturerService(ILecturerRepository lecturerRepository, IUserRepository userRepository,
            IRoleRepository roleRepository, IDepartmentRepository departmentRepository)
        {
            _lecturerRepository = lecturerRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
        }

        public LecturerResponseModel DeleteLecturer(int id)
        {
            var lecturer = _lecturerRepository.FindLecturerById(id);
            if(lecturer == null)
            {
                return new LecturerResponseModel
                {
                    Status = false,
                    Message = "Lecturer does not exist"
                };   
            }
            _lecturerRepository.DeleteLecturer(id);
            return new LecturerResponseModel
            {
                Status = true,
                Message = "Lecturer deleted successfully"
            };
        }

        public LecturersResponseModel GetAllLecturer()
        {
            var lecturers = _lecturerRepository.GetAlllecturers();
            var returnedLecturer = lecturers.Select(l => new LecturerDto
            {
                Id = l.Id,
                FirstName = l.FirstName,
                LastName = l.LastName,

            }).ToList();
            return new LecturersResponseModel
            {
                Data = returnedLecturer,
                Status = true,
                Message = "Lecturers datas retreived"
            };
        }

        public LecturerResponseModel GetLecturerById(int id)
        {
           var lecturer = _lecturerRepository.FindLecturerById(id);
            if(lecturer == null)
            {
                return new LecturerResponseModel
                {
                    Status = false,
                    Message = "Lecturer does not exist"
                };
            }
            return new LecturerResponseModel
            {
                Data = new LecturerDto
                {
                    FirstName = lecturer.FirstName,
                    LastName = lecturer.LastName,
                    Email = lecturer.Email,
                    lecturerCode = lecturer.LecturerCode
                },
                Status = true,
                Message = "Lescturer details Retrieved successfully"
            };
        }

        public BaseResponse RegisterLecturer(CreateLecturerRequestModel model)
        {
            var userExist = _userRepository.FindUserByEmail(model.Email);
            if(userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "User Already Exist"
                };
            }
            var lecturerExist = _lecturerRepository.Exists(model.FirstName, model.LastName);
            if(lecturerExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Lecturer Already Exist"
                };
            }
            var role = _roleRepository.FindRoleByName("Lecturer");
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = Guid.NewGuid().ToString(),
                PasswordHash = hashedPassword
                  
            };
            var lecturer = new Lecturer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DepartmentId = model.DepartmentId,
                LecturerCode = $"L{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
                User = user,
                UserId = user.Id
                
            };
            _userRepository.AddUser(user);
            _lecturerRepository.AddLecturer(lecturer);
            return new BaseResponse
            {
                Status = true,
                Message = "Lecturer Registered Successfully"
            };
        }

        public BaseResponse UpdateLecturer(int id, UpdateLecturerRequestModel model)
        {
            var lecturer = _lecturerRepository.FindLecturerById(id);
            if(lecturer == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Lecturer does not exist"
                };
            }
            lecturer.Email = model.Email;
            lecturer.LastName = model.LastName;
            _lecturerRepository.UpdateLecturer(lecturer);
            return new BaseResponse
            {
                Status = true,
                Message = "Updated Successfully"
            };
        }
    }
}
