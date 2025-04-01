using ScrollsTracker.Api.Services;
using ScrollsTracker.Api.Services.Interface;

namespace ScrollsTracker.Api.Config
{
    public static class ServiceConfig
    {
        public static void AddConfigService(this IServiceCollection services)
        {
            services.AddHttpClient<MangaService>();
            services.AddHostedService<ScrollTrackerJobService>();
            services.AddScoped<IImagemService, ImagemService>();
        }
    }
}
