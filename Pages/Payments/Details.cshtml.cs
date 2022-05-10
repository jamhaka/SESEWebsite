#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SESEWebsite.Data;
using SESEWebsite.Models.Payment;

namespace SESEWebsite.Pages.Payments
{
    public class DetailsModel : PageModel
    {
        private readonly SESEWebsite.Data.SESEDbContext _context;

        public DetailsModel(SESEWebsite.Data.SESEDbContext context)
        {
            _context = context;
        }

        public TransactionModel TransactionModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionModel = await _context.Transactions.FirstOrDefaultAsync(m => m.Id == id);

            if (TransactionModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
