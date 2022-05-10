using Microsoft.AspNetCore.Mvc;
using PayStack.Net;
using SESEWebsite.Data;
using SESEWebsite.Models.Payment;

namespace SESEWebsite.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SESEDbContext _context;
        private readonly string token;
        private PayStackApi PayStack { get; set; }
        public PaymentsController(IConfiguration configuration, SESEDbContext context)
        {
            _configuration = configuration;
            _context = context;
            token = _configuration["Payment:PaystackSK"];
            PayStack = new PayStackApi(token);

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PaymentIndex(PaymentViewModel paymentD) {


            TransactionInitializeRequest request = new()
          
            {
                AmountInKobo = paymentD.Amount*100,
                Email = paymentD.Email,
                Reference = Generate().ToString(),
                Currency = "NGN",
                CallbackUrl = "http://localhost:65080/Payment/Verify"
            };
            TransactionInitializeResponse response = PayStack.Transactions.Initialize(request);
            if (response.Status)
            {
                var transaction = new TransactionModel()
                {
                    Amount = paymentD.Amount,
                    Email = paymentD.Email,
                    TxrRef = request.Reference,
                    Name = paymentD.Name
                };
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                Redirect(response.Data.AuthorizationUrl);
            }
            ViewData["Error"] = response.Message;
            return View();
        }
    

        public IActionResult Payments()
        {
            var transactions = _context.Transactions.Where(x => x.Status == true).ToList();
            ViewData["transactions"] = transactions;
            return View();
        }
         [HttpGet]
         public async Task <IActionResult> Verify(string refference)
        {
            TransactionVerifyResponse response = PayStack.Transactions.Verify(refference);
            if(response.Data.Status == "success")
            {
                var transaction = _context.Transactions.Where(x => x.TxrRef == refference).FirstOrDefault();
                if(transaction != null)
                {
                    transaction.Status = true;
                    _context.Transactions.Update(transaction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Payment");
                }
            }
            ViewData["error"] = response.Data.GatewayResponse;
            return RedirectToAction("Index");
        }
    public static int Generate()
    {
        Random rand = new Random((int)DateTime.Now.Ticks);
        return rand.Next(100000000, 999999999);
    }
    }
}

