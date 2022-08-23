using HazarVentures.DTOs;
using HazarVentures.Entities;
using HazarVentures.Interfaces.Respositories;
using HazarVentures.Interfaces.Services;
using HazarVentures.Models;
using HazarVentures.ViewModels.RequestModels;
using HazarVentures.ViewModels.ResponseModels;
using System.Linq;

namespace HazarVentures.Implementations.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public BaseResponse AddDepartment(CreateDepartmentRequestModel model)
        {
            var departmentexist = _departmentRepository.Exists(model.Name);
            if(departmentexist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Department already exist"
                };
            }
            var department = new Department
            {
                Name = model.Name,
                Description = model.Description,  
            };
            _departmentRepository.AddDepartment(department);
            return new BaseResponse
            {
                Status = true,
                Message = "Department Added successfully"
            };
        }

        public DepartmentResponseModel DeleteDepartment(int id)
        {
            var department = _departmentRepository.FindDepartmentById(id);
            if(department == null)
            {
                return new DepartmentResponseModel
                {
                    Status = false,
                    Message = "Department does not exist"
                };
            }
            _departmentRepository.DeleteDepartment(id);
            return new DepartmentResponseModel
            {
                Status = true,
                Message = "Department Deleted successfully"
            };

        }

        public DepartmentsResponseModel GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();
            var returnedDepartments = departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            }).ToList();
            return new DepartmentsResponseModel
            {
                Data = returnedDepartments,
                Status = true
            };
        }

        public DepartmentResponseModel GetDepartmentById(int id)
        {
            var department = _departmentRepository.FindDepartmentById(id);
            if(department == null)
            {
                return new DepartmentResponseModel
                {
                    Status = false,
                    Message = "Department does not exist"
                };
            }
            return new DepartmentResponseModel
            {
                Data = new DepartmentDto
                {
                    Name = department.Name,
                    Description = department.Description
                },
                Status = true,
                Message = "Department details retreived successfully"
            };
        }

        public BaseResponse UpdateDepartment(int id, UpdateDepartmentRequestModel model)
        {
            var department = _departmentRepository.FindDepartmentById(id);
            if(department == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Department does not exist"
                };
            }
            model.Name = department.Name;
            model.Description = department.Description;
            _departmentRepository.UpdateDepartment(department);
            return new BaseResponse
            {
                Status = true,
                Message = "Update successfull"
            };

        }
    }
}
