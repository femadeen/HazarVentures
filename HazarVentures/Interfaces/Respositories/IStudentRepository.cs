using HazarVentures.Entities;
using System.Collections.Generic;

namespace HazarVentures.Interfaces.Respositories
{
    public interface IStudentRepository
    {
        public Student AddStudent(Student student);
        public Student FindStudentById(int id);
        public Student FindStudentByEmail(string email);
        public void DeleteStudent(int id);
        public Student UpdateStudent(Student student);
        public List<Student> GetAllStudents();
        public bool Exists(string firstName, string lastName);
    }

        
}
