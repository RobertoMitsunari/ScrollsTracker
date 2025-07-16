using MediatR;
using Microsoft.Extensions.Logging;
using ScrollsTracker.Application.Commands;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Interfaces.Repository;

namespace ScrollsTracker.Application.Handlers
{
	public class ProcurarECadastrarObraCommandHandler : IRequestHandler<ProcurarECadastrarObraCommand, int>
	{
		private readonly IObraRepository _obraRepository;
		private readonly IObraAggregatorService _aggregatorService;
		private readonly ILogger<ProcurarECadastrarObraCommandHandler> _logger;

		public ProcurarECadastrarObraCommandHandler(
			IObraRepository obraRepository,
			IObraAggregatorService aggregatorService,
			ILogger<ProcurarECadastrarObraCommandHandler> logger)
		{
			_obraRepository = obraRepository;
			_aggregatorService = aggregatorService;
			_logger = logger;
		}

		// Sei que não faz muito sentido ter uma facade e um handler fazendo as mesmas coisas,
		// mas como a ideia desse projeto é aprender coisas novas e testar conceitos, vou manter assim por enquanto.
		public async Task<int> Handle(ProcurarECadastrarObraCommand request, CancellationToken cancellationToken)
		{
			_logger.LogInformation("Iniciando processo de registro para a obra: {Titulo}", request.Titulo);
			//TODO: Add try catch?
			var novaObra = await _aggregatorService.BuscarObraAgregadaAsync(request.Titulo);

			var executado = await _obraRepository.AddAsync(novaObra);

			if (executado <= 0)
			{
				_logger.LogError("Falha ao registrar a obra: {Titulo}", request.Titulo);
				throw new Exception("Erro ao registrar a obra no banco de dados.");
			}

			_logger.LogInformation($"Obra registrada no banco com o ID: {novaObra.Id}");

			return novaObra.Id;
		}
	}
}
