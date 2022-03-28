#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SESEWebsite.Models;

namespace SESEWebsite.Data
{
    public class SESEWebsiteContext : DbContext
    {
        public SESEWebsiteContext (DbContextOptions<SESEWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<SESEWebsite.Models.Register> Register { get; set; }
    }
}
