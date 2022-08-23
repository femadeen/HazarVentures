using HazarVentures.Entities;
using HazarVentures.HazarContext;
using HazarVentures.Interfaces.Respositories;
using System.Collections.Generic;
using System.Linq;

namespace HazarVentures.Implementations.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HazarDbContext _context;
        public DepartmentRepository(HazarDbContext context)
        {
            _context = context;
        }

        public Department AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public void DeleteDepartment(int id)
        {
            var department = FindDepartmentById(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();

        }

        public bool Exists(string name)
        {
            var isExisting = _context.Departments.Any(d => d.Name.ToLower() == name.ToLower());
            return isExisting;
        }

        public Department FindDepartmentById(int id)
        {
            var department = _context.Departments.SingleOrDefault(d => d.Id == id);
            return department;
        }
        

        public List<Department> GetAllDepartments()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public Department UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return department;
        }
    }
}
