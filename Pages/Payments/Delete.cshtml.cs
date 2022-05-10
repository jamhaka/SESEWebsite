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
    public class DeleteModel : PageModel
    {
        private readonly SESEWebsite.Data.SESEDbContext _context;

        public DeleteModel(SESEWebsite.Data.SESEDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionModel = await _context.Transactions.FindAsync(id);

            if (TransactionModel != null)
            {
                _context.Transactions.Remove(TransactionModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
