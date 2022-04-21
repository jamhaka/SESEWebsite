using SESEWebsite.Data;
using SESEWebsite.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SESEWebsite.Models
{
    public class Register:Base
    {
                 
             
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string FirstName { get; set;} = string.Empty;
        [Required]
        public string LastName { get; set;}= string.Empty;
        public string? OtherName { get; set;}    = string.Empty ;
        public GenderType Gender { get; set; }
        public string FullName { get; set;} = string.Empty ;    
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        
        [DataType(DataType.PhoneNumber, ErrorMessage ="Your Phone Number Please")]
        public string PhoneNumber { get; set; } 
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } = string.Empty;

        [Required]
        public Programs Program { get; set; }
        public StudyMode Mode { get; set; } 
        public ClassCategories ProposedClass { get; set; }


        [Required]
        [DataType(DataType.Password, ErrorMessage ="Wrong Password")]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage ="Password Not Matched")]

        public string ConfirmPassword { get; set; } = string.Empty;
        //Navigaton Properties
         public IList<Enrollments>? Enrollments { get; set; }
        public Register()
        {
                FullName = FirstName + " " + LastName + "" + OtherName;
           
        }
    }
}
