using BCrypt.Net;
using HazarVentures.DTOs;
using HazarVentures.Interfaces.Respositories;
using HazarVentures.Interfaces.Services;
using HazarVentures.ViewModels.RequestModels;
using HazarVentures.ViewModels.ResponseModels;
using System.Linq;

namespace HazarVentures.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly ILecturerRepository _LecturerRepository;
        private readonly IUserRepository _UserRepository;
        public UserService(IStudentRepository studentRepository, ILecturerRepository lecturerRepository, IUserRepository userRepository)
        {
            _StudentRepository = studentRepository;
            _LecturerRepository = lecturerRepository;
            _UserRepository = userRepository;
        }

        public UsersResponseModel GetAllUSers()
        {
            var users = _UserRepository.GetAllUsers();
            var returnedUSer = users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                RoleId = u.RoleId,
                
            });
            return new UsersResponseModel
            {
                Data = returnedUSer,
                Status = true,
                Message = " USers retreived successfully"
            };
        }

        public UserResponseModel GetUserById(int id)
        {
            var user = _UserRepository.FindUserById(id);
            if(user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = "No such user exist"
                };
            }
            if (user.Role.Name.ToLower() == "student")
            {
                return new UserResponseModel
                {
                    Data = new UserDto
                    {
                        Email = user.Email,
                        FirstName = user.Student.FirstName,
                        LastName = user.Student.LastName,
                        DepartmentName = user.Student.Department.Name,
                        RoleName = user.Role.Name,
                        StudentId = user.Student.Id,
                       
                    },
                    Status = true,
                    Message = " Student User Retreived Successfully"

                };
            }
            else
            {
                return new UserResponseModel
                {
                    Data = new UserDto
                    {
                        Email = user.Email,
                        FirstName = user.Lecturer.FirstName,
                        LastName = user.Lecturer.LastName,
                        DepartmentName = user.Lecturer.Department.Name,
                        RoleName = user.Role.Name,
                        LecturerId = user.Lecturer.Id
                    },
                    Status = true,
                    Message = "Lecturer User retrieved Successfully"
                };

            };
               
                
        }

        public UserResponseModel Login(LoginRequestModel model)
        {
            var user = _UserRepository.FindUserByEmail(model.Email);
            if(user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = " No such user exist"
                };
            };
            var passwordCheck = BCrypt.Net.BCrypt.Verify($"{model.Password}{user.HashSalt}" , user.PasswordHash);
            if(passwordCheck)
            {
                if (user.Role.Name.ToLower() == "student")
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.Student.FirstName,
                            LastName = user.Student.LastName,
                            DepartmentName = user.Student.Department.Name,
                            RoleName = user.Role.Name
                        },
                        Status = true,
                        Message = " Student User Retreived Successfully"

                    };
                }
                else
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.Lecturer.FirstName,
                            LastName = user.Lecturer.LastName,
                            DepartmentName = user.Lecturer.Department.Name,
                            RoleName = user.Role.Name
                        },
                        Status = true,
                        Message = "Lecturer User retrieved Successfully"
                    };

                };
            }
            return new UserResponseModel
            {
                Status = false,
                Message = " No such user exist"
            };

        }
    }
}
