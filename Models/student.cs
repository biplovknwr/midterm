﻿namespace _200604735.Models
{
    public class Student
    {
        public int StudentId { get; set; }  
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; } // Nullable email
        public int Age { get; set; }
    }
}


