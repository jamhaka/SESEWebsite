using SESEWebsite.Models.Enum;

namespace SESEWebsite.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Instructors { get; set; }
        public CreditEnum Creadits { get; set; }
        
        //Navigation property
        public virtual Instructor Instructor { get; set; }

    }
}
