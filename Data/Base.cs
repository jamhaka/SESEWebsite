namespace SESEWebsite.Data
{
    public class Base
    {
        public int Id { get; init;}
        public virtual DateTime RegistredDate { get; set; } 
        public bool IsDeleted { get; set; } 


        public Base()
        {
                Id = new();
            RegistredDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
