using System.Collections.Generic;

namespace HazarVentures.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> UserDto { get; set; } = new List<UserDto>();
    }
}
