namespace LojaMvc.DependencyInjections;

public static class LojaAutenticacaoDependencyInjection
{
    public static IServiceCollection AddLojaAuthentication(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        
        return services;
    }
}