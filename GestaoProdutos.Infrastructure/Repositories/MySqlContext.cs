using GestaoProdutos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutos.Infrastructure.Repositories
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) 
            : base(options) { }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.CodProduto);

            base.OnModelCreating(modelBuilder);
        }
    }
}
