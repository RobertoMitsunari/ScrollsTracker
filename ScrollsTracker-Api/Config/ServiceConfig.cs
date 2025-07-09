using ScrollsTracker.Application.Services;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Infra.Sources;

namespace ScrollsTracker.Api.Config
{
    public static class ServiceConfig
    {
        public static void AddConfigService(this IServiceCollection services)
        {
            //services.AddHttpClient<IObraSource, MangaUpdateSource>();
			services.AddHttpClient<IObraSource, MangaDexSource>();
		}
    }
}
