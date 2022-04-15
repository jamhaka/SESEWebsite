namespace SESEWebsite.Data
{
    public class Base
    {
        public Guid Id { get; set; }
        public DateTime RegistredDate { get; set; }  


        public Base()
        {
                Id = Guid.NewGuid();
            RegistredDate = DateTime.Now;
        }
    }
}
