using LojaRepositorios.database;
using LojaRepositorios.repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LojaRepositorios.DependencyInjections
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
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            return services;
        }

        public static IServiceCollection AddDataBaseSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<LojaContexto>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
