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
        private readonly SESEWebsite.Data.SESEWebsiteContext _context;

        public DeleteModel(SESEWebsite.Data.SESEWebsiteContext context)
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

            Register = await _context.Register.FirstOrDefaultAsync(m => m.Id == id);

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

            Register = await _context.Register.FindAsync(id);

            if (Register != null)
            {
                _context.Register.Remove(Register);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
