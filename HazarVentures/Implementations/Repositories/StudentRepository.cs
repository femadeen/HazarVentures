using HazarVentures.Entities;
using HazarVentures.HazarContext;
using HazarVentures.Interfaces.Respositories;
using System.Collections.Generic;
using System.Linq;

namespace HazarVentures.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HazarDbContext _context;
        public StudentRepository(HazarDbContext context)
        {
            _context = context;
        }
        public Student AddStudent(Student student)
        {
           _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void DeleteStudent(int id)
        {
            var student = FindStudentById(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public bool Exists(string firstName, string lastName)
        {
            var isExisting = _context.Students.Any(s => s.FirstName.ToLower() == firstName.ToLower()
            && s.LastName.ToLower() == lastName.ToLower());
            return isExisting;
        }

        public Student FindStudentByEmail(string email)
        {
            var student = _context.Students.FirstOrDefault(s => s.Email.ToLower() == email.ToLower());
            return student;
        }

        public Student FindStudentById(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            var students = _context.Students.ToList();
            return students;
        }

        public Student UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }
    }
}
