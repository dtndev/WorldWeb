namespace WorldWeb.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using WorldWeb.Core.Repositories;
    using WorldWeb.Infrastructure.Repositories;

    public static class WorldWebServiceCollectionExtensions
    {
        public static void AddWorldWebInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<SqlConnectionProvider>();
            services.AddSingleton<IWorldRepository, SqlServerWorldRepository>();
        }
    }
}
