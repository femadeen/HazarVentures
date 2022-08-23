using HazarVentures.Entities;
using System.Collections.Generic;

namespace HazarVentures.Interfaces.Respositories
{
    public interface ILecturerRepository
    {
        public Lecturer AddLecturer(Lecturer lecturer);
        public Lecturer FindLecturerById(int id);
        public Lecturer FindLecturerByEmail(string email);
        public void DeleteLecturer(int id);
        public Lecturer UpdateLecturer(Lecturer lecturer);
        public List<Lecturer> GetAlllecturers();
        public bool Exists(string FirstName, string LastName);

    }
}
