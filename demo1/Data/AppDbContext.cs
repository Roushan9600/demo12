using demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace demo1.Data {
    public class AppDbContext :DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Employees> employees { get; set; }
    }
}
