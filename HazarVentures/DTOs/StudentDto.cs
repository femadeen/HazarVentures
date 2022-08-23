﻿using HazarVentures.Entities;

namespace HazarVentures.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public int StudentCode { get; set; }
        public UserDto UserDto { get; set; }

    }
}
