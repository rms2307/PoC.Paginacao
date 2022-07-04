using Microsoft.EntityFrameworkCore;
using PoC.Paginacao.Models;

namespace PoC.Paginacao.Context
{
    public class PoCContext : DbContext
    {
        public PoCContext(DbContextOptions<PoCContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
