using System;

namespace UniversityWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
