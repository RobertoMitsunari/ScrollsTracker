using Microsoft.Extensions.Logging;
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
			var obraFinal = new Obra { Titulo = titulo };

			foreach (var source in _sources)
			{
				try
				{
					var obraEncontrada = await source.ObterObraAsync(titulo);
					if (obraEncontrada != null)
					{
						MergeObras(obraFinal, obraEncontrada);
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, $"Falha ao buscar dados da fonte: {source.SourceName}");
					// Continue para a próxima fonte, não pare o processo
				}
			}

			return obraFinal;
		}

		
		private void MergeObras(Obra principal, Obra dadosNovos)
		{
			if (string.IsNullOrEmpty(principal.Titulo))
				principal.Titulo = dadosNovos.Titulo;

			if (principal.TotalCapitulos == 0)
				principal.TotalCapitulos = dadosNovos.TotalCapitulos;

			if (string.IsNullOrEmpty(principal.Descricao))
				principal.Descricao = dadosNovos.Descricao;

			if (string.IsNullOrEmpty(principal.Status))
				principal.Status = dadosNovos.Status;
		}
	}
}
