using System.Collections.Generic;

namespace UniversityWebApp.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Dean { get; set; } = "";
        
        // Navigation property
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
