using System;
using Microsoft.EntityFrameworkCore;
namespace Week1_Patika.DbOperations

{
    
        public class CakeShopDbContext : DbContext
        {
            public CakeShopDbContext(DbContextOptions<CakeShopDbContext> options) : base(options)
            { }
            public DbSet<Cake> Cakes { get; set; }
    }
    
}


