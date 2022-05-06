using SESEWebsite.Data;

namespace SESEWebsite.Models.Payment
{
    public class TransactionModel:Base
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Email { get; set; }
        public string TxrRef { get; set; }  
    }
}
