using SESEWebsite.Data;
using SESEWebsite.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace SESEWebsite.Models
{
    public class Instructor:Base 
    { 
        [NotMapped]
        public IFormFile formFile { get; set; }
        public string FName { get; set; }
        public string SurName { get; set; } 
        public string BIO { get; set; }
        public string Course { get; set; }  
        public Departments Department { get; set; }
        //Navigation
        public IList<Course> Courses { get; set; }
    }
}
