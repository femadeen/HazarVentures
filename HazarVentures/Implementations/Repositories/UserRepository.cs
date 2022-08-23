using HazarVentures.Entities;
using HazarVentures.HazarContext;
using HazarVentures.Interfaces.Respositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HazarVentures.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HazarDbContext _context;
        public UserRepository(HazarDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = FindUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User FindUserByEmail(string email)
        {
            var user = _context.Users
                .Include(r => r.Role)
                .Include(u => u.Student)
                .ThenInclude(s => s.Department)
                .Include(u => u.Lecturer)
                .ThenInclude(l => l.Department)
                .FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            return user;
        }

        public User FindUserById(int id)
        {
            var user = _context.Users
                .Include(r => r.Role)
                .Include(u => u.Student)
                .ThenInclude(s => s.Department)
                .Include(u => u.Lecturer)
                .ThenInclude(l => l.Department)
                .SingleOrDefault(u => u.Id == id);
            return user;
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
