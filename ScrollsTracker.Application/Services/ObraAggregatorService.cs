using Microsoft.Extensions.Logging;
using ScrollsTracker.Application.Services.Filter;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Application.Services
{
	public class ObraAggregatorService : IObraAggregatorService
	{
        public readonly IEnumerable<IObraSource> _sources;
        private readonly ILogger<ObraAggregatorService> _logger;

		public ObraAggregatorService(IEnumerable<IObraSource> sources, ILogger<ObraAggregatorService> logger)
		{
			_sources = sources;
			_logger = logger;
		}

		public async Task<Obra> BuscarObraAgregadaAsync(string titulo)
		{
			var obraFilter = new ObraFilter(titulo);

			foreach (var source in _sources)
			{
				try
				{
					var obraEncontrada = await source.ObterObraAsync(titulo);
					if (obraEncontrada != null)
					{
						obraFilter.Filtrar(obraEncontrada, source.SourceName);
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, $"Falha ao buscar dados da fonte: {source.SourceName}");
				}
			}

			return obraFilter.ObraFiltrada;
		}

		//TODO: Esse método pode ser melhorado com o filtro ficando mais inteligente
		// Ele tmb poderia dizer se a obra foi atualizada ou n
		public async Task<Obra> BuscarEAtualizaObraAsync(Obra obra)
		{
			var obraFilter = new ObraFilter(obra);

			foreach (var source in _sources)
			{
				try
				{
					var obraEncontrada = await source.ObterObraAsync(obra.Titulo!);
					if (obraEncontrada != null)
					{
						obraFilter.Filtrar(obraEncontrada, source.SourceName);
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, $"Falha ao buscar dados da fonte: {source.SourceName}");
				}
			}

			obraFilter.ObraFiltrada.DataVerificacao = DateTime.Now;
			return obraFilter.ObraFiltrada;
		}
	}
}
