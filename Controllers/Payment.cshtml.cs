using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SESEWebsite.Controllers
{
    public class PaymentModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult Index()
        {
            return Page();
        }

        
        public IActionResult PaymentLink()
        {
            return Page();
        }
        public IActionResult Verify()
        {
            return Page();
        }
    }
}
