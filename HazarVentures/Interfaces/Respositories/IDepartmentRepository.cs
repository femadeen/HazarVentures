using HazarVentures.Entities;
using System.Collections.Generic;

namespace HazarVentures.Interfaces.Respositories
{
    public interface IDepartmentRepository
    {
        public Department AddDepartment(Department department);
        public Department FindDepartmentById(int id);
        public void DeleteDepartment(int id);
        public Department UpdateDepartment(Department department);
        public List<Department> GetAllDepartments();
        public bool Exists(string name);
    }
}
