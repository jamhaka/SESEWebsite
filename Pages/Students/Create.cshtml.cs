#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SESEWebsite.Data;
using SESEWebsite.Models;

namespace SESEWebsite.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SESEWebsite.Data.SESEWebsiteContext _context;

        public CreateModel(SESEWebsite.Data.SESEWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Register Register { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Register.Add(Register);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
