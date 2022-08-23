using HazarVentures.Entities;
using HazarVentures.HazarContext;
using HazarVentures.Interfaces.Respositories;
using System.Collections.Generic;
using System.Linq;

namespace HazarVentures.Implementations.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private readonly HazarDbContext _context;
        public LecturerRepository(HazarDbContext context)
        {
            _context = context;
        }

        public Lecturer AddLecturer(Lecturer lecturer)
        {
            _context.Lecturers.Add(lecturer);
            _context.SaveChanges();
            return lecturer;
        }

        public void DeleteLecturer(int id)
        {
           var lecturer = FindLecturerById(id);
            _context.Lecturers.Remove(lecturer);
            _context.SaveChanges();
        }

        public bool Exists(string FirstName, string LastName)
        {
            var isExisting = _context.Lecturers.Any(l => l.FirstName.ToLower()
            == FirstName.ToLower() && l.LastName.ToLower() == LastName);
            return isExisting;
        }

        public Lecturer FindLecturerById(int id)
        {
            var lecturer = _context.Lecturers.SingleOrDefault(l => l.Id == id);
            return lecturer;
        }

        public Lecturer FindLecturerByEmail(string email)
        {
            var lecturer = _context.Lecturers.FirstOrDefault(l => l.Email.ToLower() == email.ToLower());
            return lecturer;
        }

        public List<Lecturer> GetAlllecturers()
        {
            var lectueres = _context.Lecturers.ToList();
            return lectueres;
        }

        public Lecturer UpdateLecturer(Lecturer lecturer)
        {
            _context.Lecturers.Update(lecturer);
            _context.SaveChanges();
            return lecturer;
        }
    }
}
