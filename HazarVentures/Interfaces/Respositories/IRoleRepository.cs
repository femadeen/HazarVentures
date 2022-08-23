using HazarVentures.Entities;
using System.Collections.Generic;

namespace HazarVentures.Interfaces.Respositories
{
    public interface IRoleRepository
    {
        public Role AddRole(Role role);
        public Role FindRoleById(int id);
        public Role FindRoleByName(string name);
        public void DeleteRole(int id);
        public Role UpdateRole(Role role);
        public List<Role> GetAllRoles();
    }
}
