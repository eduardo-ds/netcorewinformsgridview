using Microsoft.EntityFrameworkCore;

namespace MeuProjetoWinForms.App
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=produtos.db");
        }
    }
}
