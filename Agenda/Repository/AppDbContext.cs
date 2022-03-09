using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
          
        }
        public DbSet<Pessoa> Pessoas { get; set; }
}
}
