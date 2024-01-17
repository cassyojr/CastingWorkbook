using CastingWorkbook.Repository.Interfaces;
using CastingWorkbook.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CastingWorkbook.Repository.Infrastructure
{
    public static class RepositoryInfrastructure
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();

            return services;
        }
    }
}
