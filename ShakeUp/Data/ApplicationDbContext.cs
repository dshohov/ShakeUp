using Microsoft.EntityFrameworkCore;
using ShakeUp.Models;

namespace ShakeUp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Alcohol> Alcohols { get; set; }
    }
}
