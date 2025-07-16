using Microsoft.Extensions.Logging;
using ScrollsTracker.Domain.Interfaces.Repository;
using ScrollsTracker.Domain.Interfaces;
using MediatR;
using ScrollsTracker.Application.Commands;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Application.Handlers
{
	public class AtualizarObrasCommandHandler : IRequestHandler<AtualizarObrasCommand>
	{
		private readonly IObraRepository _obraRepository;
		private readonly IObraAggregatorService _aggregatorService;
		private readonly ILogger<AtualizarObrasCommandHandler> _logger;

		public AtualizarObrasCommandHandler(IObraRepository obraRepository, IObraAggregatorService aggregatorService, ILogger<AtualizarObrasCommandHandler> logger)
		{
			_obraRepository = obraRepository;
			_aggregatorService = aggregatorService;
			_logger = logger;
		}

		public async Task Handle(AtualizarObrasCommand request, CancellationToken cancellationToken)
		{
			var obras = await _obraRepository.ObterTodasObrasParaAtualizarAsync();

			if (obras == null || !obras.Any())
			{
				_logger.LogWarning("Nenhuma obra encontrada para atualização.");
				return;
			}

			_logger.LogInformation("Iniciando atualização de obras...");

			//TODO: Esse método provavelmente vai dar problema no futuro caso tenha muitas obras.
			foreach (Obra obra in obras) 
			{
				var obraAtualizada = await _aggregatorService.BuscarEAtualizaObraAsync(obra);
				var result = await _obraRepository.UpdateObraAsync(obraAtualizada);

				if(result >= 1) 
				{
					_logger.LogInformation($"Obra {obraAtualizada.Titulo} atualizada com sucesso. ID: {obraAtualizada.Id}");
				}
				else
				{
					_logger.LogWarning($"Falha ao atualizar a obra {obraAtualizada.Titulo}. ID: {obraAtualizada.Id}");
				}
			}
		}
	}
}
