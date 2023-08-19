using LojaRepositorios.database;
using LojaRepositorios.repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LojaServicos.DependencyInjections
{
    public static class RepositoriesDependencyInjection
    {
        public static IServiceCollection AddRepositoriesDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddDataBaseSqlServer(configuration);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            return services;
        }

        public static IServiceCollection AddDataBaseSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerArquivo");

            services.AddDbContext<LojaContexto>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
