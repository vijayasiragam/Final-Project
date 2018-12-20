using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System;

namespace FinalProject.Models
{
    public class LunchContext:DbContext
    {
        public LunchContext(DbContextOptions<LunchContext>options):base(options)
        {

        }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<PAdmin> PAdmins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Invoice>Invoices { get; set; }

        
    }
}