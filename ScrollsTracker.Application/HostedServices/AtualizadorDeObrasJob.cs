using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ScrollsTracker.Application.Commands;

namespace ScrollsTracker.Application.HostedServices
{
	public class AtualizadorDeObrasJob : IHostedService, IDisposable
	{
		private readonly ILogger<AtualizadorDeObrasJob> _logger;
		private readonly IServiceProvider _serviceProvider;
		private Timer? _timer = null;

		public AtualizadorDeObrasJob(ILogger<AtualizadorDeObrasJob> logger, IServiceProvider serviceProvider)
		{
			_logger = logger;
			_serviceProvider = serviceProvider;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Serviço de Atualização de Obras em Background está iniciando.");

			_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));

			return Task.CompletedTask;
		}

		private void DoWork(object? state)
		{
			_logger.LogInformation("Executando tarefa agendada de atualização de obras.");

			using (var scope = _serviceProvider.CreateScope())
			{
				var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

				try
				{
					mediator.Send(new AtualizarObrasCommand()).Wait();
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Falha ao executar a tarefa agendada de atualização para as obras");
				}
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Serviço de Atualização de Obras em Background está parando.");
			_timer?.Change(Timeout.Infinite, 0);
			return Task.CompletedTask;
		}

		public void Dispose()
		{
			_timer?.Dispose();
		}
	}
}
