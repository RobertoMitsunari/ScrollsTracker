using ScrollsTracker.Domain.Enum;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Application.Services.Filter
{
    public class ObraFilter : IObraFilter
	{
		private readonly Obra _obra;

		public ObraFilter(string titulo)
		{
			_obra = new Obra { Titulo = titulo };
		}

		public ObraFilter(Obra obra)
		{
			_obra = obra;
		}

		public void Filtrar(Obra obra, EnumSources novaOrigem)
		{
			FiltrarTitulo(obra, novaOrigem);
			FiltrarDescricao(obra, novaOrigem);
			FiltrarTotalCapitulos(obra, novaOrigem);
			FiltrarImagem(obra, novaOrigem);
			FiltrarStatus(obra, novaOrigem);
		}

		public Obra ObraFiltrada => _obra;

		private void FiltrarImagem(Obra obra, EnumSources novaOrigem)
		{
			if(string.IsNullOrEmpty(_obra.Imagem))
			{
				_obra.Imagem = obra.Imagem;
			}

			if (novaOrigem == EnumSources.MangaDex && !string.IsNullOrEmpty(obra.Imagem))
			{
				_obra.Imagem = obra.Imagem;
			}
		}

		private void FiltrarStatus(Obra obra, EnumSources novaOrigem)
		{
			if(string.IsNullOrEmpty(_obra.Status))
			{
				_obra.Status = obra.Status;
			}
			
			if (novaOrigem == EnumSources.MangaDex && !string.IsNullOrEmpty(obra.Status))
			{
				_obra.Status = obra.Status;
			}
		}

		private void FiltrarTotalCapitulos(Obra obra, EnumSources novaOrigem)
		{
			if (_obra.TotalCapitulos == 0)
			{
				_obra.TotalCapitulos = obra.TotalCapitulos;
			}

			if (obra.TotalCapitulos > _obra.TotalCapitulos)
			{
				_obra.TotalCapitulos = obra.TotalCapitulos;
			}
		}

		private void FiltrarDescricao(Obra obra, EnumSources novaOrigem)
		{
			if (string.IsNullOrEmpty(_obra.Descricao))
			{
				_obra.Descricao = obra.Descricao;
			}

			if (novaOrigem == EnumSources.MangaDex && !string.IsNullOrEmpty(obra.Descricao))
			{
				_obra.Descricao = obra.Descricao;
			}
		}

		private void FiltrarTitulo(Obra obra, EnumSources novaOrigem)
		{
			if (string.IsNullOrEmpty(_obra.Titulo))
			{
				_obra.Titulo = obra.Titulo;
			}
		}
	}
}
