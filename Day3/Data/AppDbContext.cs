using Microsoft.EntityFrameworkCore;
using Day3.Models;

namespace Day3.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
