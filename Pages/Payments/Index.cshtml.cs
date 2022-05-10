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
    public class IndexModel : PageModel
    {
        private readonly SESEWebsite.Data.SESEDbContext _context;

        public IndexModel(SESEWebsite.Data.SESEDbContext context)
        {
            _context = context;
        }

        public IList<TransactionModel> TransactionModel { get;set; }

        public async Task OnGetAsync()
        {
            TransactionModel = await _context.Transactions.ToListAsync();
        }
    }
}
