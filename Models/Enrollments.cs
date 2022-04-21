using SESEWebsite.Data;

namespace SESEWebsite.Models
{
    public class Enrollments:Base
    {
        
        public int CourseId {get; set;}
        public int StudentId {get; set;}    
        //Navigation Properties
        public Student? student { get; set; }
        public Course course { get; set; }

        public ICollection<Student> students { get; set;}
    }
}
