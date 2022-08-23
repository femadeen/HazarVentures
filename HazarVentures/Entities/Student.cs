using HazarVentures.Models;
using System.Collections.Generic;

namespace HazarVentures.Entities
{
    public class Student : Person
    {
        public string StudentCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
