#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayStack.Net;
using SESEWebsite.Data;
using SESEWebsite.Models.Payment;

namespace SESEWebsite.Pages.Payments
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly SESEWebsite.Data.SESEDbContext _context;
        private readonly string token;
        private PayStackApi PayStack { get; set; }


        public CreateModel(IConfiguration configuration,  SESEWebsite.Data.SESEDbContext context)
        {
            _context = context;
            _configuration = configuration;
            token = _configuration["Payment:Paystacks"];
            PayStack = new PayStackApi(token);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TransactionModel TransactionModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(PaymentViewModel paymentD)
        {


            TransactionInitializeRequest request = new()

            {
                AmountInKobo = paymentD.Amount * 100,
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
               return Redirect(response.Data.AuthorizationUrl);
            }
            ViewData["Error"] = response.Message;
            return Page();
        }

        public IActionResult PaymentsDetailsOnget()
        {
            var transactions = _context.Transactions.Where(x => x.Status == true).ToList();
            ViewData["transactions"] = transactions;
            return Page();
        }
        
        public async Task<IActionResult> VerifyOnget(string refference)
        {
            TransactionVerifyResponse response = PayStack.Transactions.Verify(refference);
            if (response.Data.Status == "success")
            {
                var transaction = _context.Transactions.Where(x => x.TxrRef == refference).FirstOrDefault();
                if (transaction != null)
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
    

