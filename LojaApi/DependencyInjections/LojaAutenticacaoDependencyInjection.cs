using LojaApi.Filters;

namespace LojaApi.DependencyInjections;

public static class LojaAutenticacaoDependencyInjection
{
    public static IServiceCollection AddLojaAuthentication(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        
        services.AddScoped<UsuarioAutenticadoFilter>();
        
        return services;
    }
}