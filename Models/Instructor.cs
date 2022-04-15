using SESEWebsite.Models.Enum;

namespace SESEWebsite.Models
{
    public class Instructor { 
    
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Course { get; set; }  
        public Departments Department { get; set; }
        //Navigation
        public IList<Course> Courses { get; set; }
    }
}
