using BackEndProduseCheltuieliNotite.Models.Objects;
using Microsoft.EntityFrameworkCore;
namespace BackEndProduseCheltuieliNotite.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Note> Notes { get; set; }

    }

}
