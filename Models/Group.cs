using System.Collections.Generic;

namespace UniversityWebApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int FacultyId { get; set; }
        public virtual Faculty? Faculty { get; set; }
        public int Year { get; set; }
        
        // Navigation property
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
