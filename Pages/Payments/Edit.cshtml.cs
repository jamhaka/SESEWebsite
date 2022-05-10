#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SESEWebsite.Data;
using SESEWebsite.Models.Payment;

namespace SESEWebsite.Pages.Payments
{
    public class EditModel : PageModel
    {
        private readonly SESEWebsite.Data.SESEDbContext _context;

        public EditModel(SESEWebsite.Data.SESEDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TransactionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionModelExists(TransactionModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TransactionModelExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
