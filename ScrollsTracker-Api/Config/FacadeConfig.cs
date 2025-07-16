using ScrollsTracker.Application.Facade;
using ScrollsTracker.Application.Services;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Interfaces.Facade;
using ScrollsTracker.Infra.Sources;

namespace ScrollsTracker.Api.Config
{
	public static class FacadeConfig
	{
		public static void AddConfigFacade(this IServiceCollection services)
		{
			services.AddScoped<IObraFacade, ObraFacade>();
		}
	}
}
