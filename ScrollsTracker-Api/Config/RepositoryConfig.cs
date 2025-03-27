using Microsoft.EntityFrameworkCore;
using ScrollsTracker.Api.Repository;
using ScrollsTracker.Api.Repository.Context;
using ScrollsTracker.Api.Repository.Interface;

namespace ScrollsTracker.Api.Config
{
    public static class RepositoryConfig
    {
        public static void AddConfigRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IScrollsTrackerRepository, ScrollsTrackerRepository>();
        }
    }
}
