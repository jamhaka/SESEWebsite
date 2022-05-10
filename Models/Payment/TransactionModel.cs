using SESEWebsite.Data;

namespace SESEWebsite.Models.Payment
{
    public class TransactionModel:Base
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public string TxrRef { get; set; } 
        public bool Status { get; set; }
    }
}
