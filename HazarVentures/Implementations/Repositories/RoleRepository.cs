using HazarVentures.Entities;
using HazarVentures.HazarContext;
using HazarVentures.Interfaces.Respositories;
using System.Collections.Generic;
using System.Linq;

namespace HazarVentures.Implementations.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HazarDbContext _context;
        public RoleRepository(HazarDbContext context)
        {
            _context = context;
        }

        public Role AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public void DeleteRole(int id)
        {
            var role = FindRoleById(id);
            _context.Roles.Remove(role);
            _context.SaveChanges();   
        }

        public Role FindRoleById(int id)
        {
            var role = _context.Roles.SingleOrDefault(r => r.Id == id);
            return role;
        }

        public Role FindRoleByName(string name)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == name);
            return role;
        }

        public List<Role> GetAllRoles()
        {
            var roles = _context.Roles.ToList();
            return roles;
        }

        public Role UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }
    }
}
