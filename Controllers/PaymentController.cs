using Microsoft.AspNetCore.Mvc;
using SESEWebsite.Models.Payment;

namespace SESEWebsite.Controllers
{
    public class PaymentController : Controller
    {
        public PaymentController()
        {
                
        }
        [HttpGet]
        public IActionResult PaymentIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PaymentIndex(PaymentViewModel paymentViewModel)
        {
            return View();
        }

        public IActionResult Payments()
        {
            return View();
        }
         [HttpGet]
         public IActionResult Verify()
        {
            return View();
        }
    }
}
