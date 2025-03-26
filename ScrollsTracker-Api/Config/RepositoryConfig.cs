using Microsoft.EntityFrameworkCore;
using ScrollsTracker.Api.Repository.Context;

namespace ScrollsTracker.Api.Config
{
    public static class RepositoryConfig
    {
        public static void AddConfigRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=scrolltracker;User Id=sa;Password=Roberto@123;TrustServerCertificate=True"));
        }
    }
}
