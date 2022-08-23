using HazarVentures.Entities;
using System.Collections.Generic;

namespace HazarVentures.Interfaces.Respositories
{
    public interface IUserRepository
    {
        public User AddUser(User user);
        public User FindUserById(int id);
        public User FindUserByEmail(string email);
        public void DeleteUser(int id);
        public User UpdateUser(User user);
        public List<User> GetAllUsers();
    }
}
