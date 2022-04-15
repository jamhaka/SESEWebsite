namespace SESEWebsite.Models
{
    public class Enrollments
    {
        public int Id { get; set; }
        public int CourseId {get; set;}
        public int StudentId {get; set;}    
        //Navigation Properties
        public Student? student { get; set; }
        public Course course { get; set; }
    }
}
