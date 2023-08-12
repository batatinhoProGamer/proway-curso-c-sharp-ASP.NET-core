using LojaRepositorios.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace LojaRepositorios.database
{
    public class LojaContexto : DbContext
    {
        public LojaContexto(DbContextOptions options): base(options)
        { 
        }
        public LojaContexto()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
        }
    }
}
