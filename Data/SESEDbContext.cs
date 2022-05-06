using Microsoft.EntityFrameworkCore;
using SESEWebsite.Models;
using SESEWebsite.Models.Payment;

namespace SESEWebsite.Data
{
    public class SESEDbContext:DbContext
    {
        private readonly DbContextOptions _options;
        public SESEDbContext(DbContextOptions<SESEDbContext> options):base(options)
        {
            _options = options;  
        }
        public DbSet<Register>? Registers { get; set; }
         public DbSet<Course>? Courses { get; set; }
        public DbSet<Enrollments>? Enrollments { get; set; } 
        public DbSet<Instructor>? Instructors { get; set; } 
        public DbSet<Student>? Students { get; set; } 
        public DbSet<TransactionModel>? Transactions { get; set; }
    }
}
