using HazarVentures.Enums;
using HazarVentures.Models;
using System.Collections.Generic;

namespace HazarVentures.Entities
{
    public class Lecturer : Person
    {
        public string LecturerCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
