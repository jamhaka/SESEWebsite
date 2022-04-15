#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SESEWebsite.Data;
using SESEWebsite.Models;

namespace SESEWebsite.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly SESEWebsite.Data.SESEDbContext _context;

        public DeleteModel(SESEWebsite.Data.SESEDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Register Register { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Register = await _context.Registers.FirstOrDefaultAsync(m => m.Id == id);

            if (Register == null)
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

            Register = await _context.Registers.FindAsync(id);

            if (Register != null)
            {
                _context.Registers.Remove(Register);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
