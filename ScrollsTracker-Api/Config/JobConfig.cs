using ScrollsTracker.Application.HostedServices;

namespace ScrollsTracker.Api.Config
{
	public static class JobConfig
	{
		public static void AddConfigJob(this IServiceCollection services)
		{
			services.AddHostedService<AtualizadorDeObrasJob>();
		}
	}
}
