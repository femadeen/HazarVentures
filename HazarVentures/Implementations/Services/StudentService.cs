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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, IRoleRepository roleRepository, IDepartmentRepository departmentRepository)
        {
            _StudentRepository = studentRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
        }

        public BaseResponse AddStudent(CreateStudentRequestModel model)
        {
            var userExist = _userRepository.FindUserByEmail(model.Email);
            if (userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "User Already Exist"
                };
            };
            var studentExist = _StudentRepository.Exists(model.FirstName, model.LastName);
            if (studentExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Student already exist"
                };
            };
            var role = _roleRepository.FindRoleByName("Student");
            var salt = Guid.NewGuid().ToString();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword($"{model.Password}{salt}");
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = salt,
                PasswordHash = hashedPassword,
            };
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                User = user,
                UserId = user.Id,
                DepartmentId = model.DepartmentId,
                StudentCode = $"L{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
                Email = model.Email,
            };
            _userRepository.AddUser(user);
            _StudentRepository.AddStudent(student);
            return new BaseResponse
            {
                Status = true,
                Message = "Student registered successfully"
            };
        }

        public DepartmentResponseModel DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public StudentsResponseModel GetAllStudents()
        {
            var students = _StudentRepository.GetAllStudents();
            var returnedStudent = students.Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName
            });
            return new StudentsResponseModel
            {
                Data = returnedStudent,
                Status = true,
                Message = " Students datas retreived successfully"
            };
        }

        public StudentResponseModel GetStudentById(int id)
        {
            var student = _StudentRepository.FindStudentById(id);
            if(student == null)
            {
                return new StudentResponseModel
                {
                    Status = false,
                    Message = "No such student exist"
                };
            }
            return new StudentResponseModel
            {
                Data = new StudentDto
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    DepartmentId = student.DepartmentId,
                },
                Status = true,
                Message = "student retreuved successfully"
            };
               


        }

        public BaseResponse UpdateStudent(int id, UpdateStudentRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
