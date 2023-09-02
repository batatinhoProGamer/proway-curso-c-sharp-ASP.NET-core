using LojaRepositorios.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace LojaRepositorios.database
{
    public class LojaContexto : DbContext
    {
        public LojaContexto(DbContextOptions options): base(options)
        {
            /*
             * - Instalar dotnet ef CLI (para poder fazer migrations e atualizar o banco)
             * dotnet tool install --global dotnet-ef --version 6.0.20
             * 
             * - Apagar a versão do dotnet ef CLI
             * dotnet tool uninstall --global dotnet-ef
             * 
             * - Buscar ferramentas com o nome dotnet-ef
             * dotnet tool search dotnet-ef
             * 
             * - Buscar detalhes
             * dotnet tool search dotnet-ef --detail 
             * 
             * - Criar migration
             * dotnet ef migrations add AddColumnActiveToAllTable --project LojaRepositorios --startup-project LojaApi
             * 
             * - Remover última migration
             * dotnet ef migrations remove --project LojaRepositorios --startup-project LojaApi
             */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
        }
    }
}
