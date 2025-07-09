using Microsoft.Extensions.Logging;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Application.Services
{
    public class ObraAggregatorService
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
			//if (string.IsNullOrEmpty(principal.Autor))
			//	principal.Autor = dadosNovos.Autor;

			//if (principal.NumeroDePaginas == 0)
			//	principal.NumeroDePaginas = dadosNovos.NumeroDePaginas;

			//if (string.IsNullOrEmpty(principal.Editora))
			//	principal.Editora = dadosNovos.Editora;

			//if (string.IsNullOrEmpty(principal.UrlCapa))
			//	principal.UrlCapa = dadosNovos.UrlCapa;
		}
	}
}
