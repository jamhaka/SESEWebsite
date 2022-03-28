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
    public class IndexModel : PageModel
    {
        private readonly SESEWebsite.Data.SESEWebsiteContext _context;

        public IndexModel(SESEWebsite.Data.SESEWebsiteContext context)
        {
            _context = context;
        }

        public IList<Register> Register { get;set; }

        public async Task OnGetAsync()
        {
            Register = await _context.Register.ToListAsync();
        }
    }
}
