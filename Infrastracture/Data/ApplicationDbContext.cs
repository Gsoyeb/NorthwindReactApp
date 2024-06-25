using Microsoft.EntityFrameworkCore;
using NorthwindReactApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindReactApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    }
}
