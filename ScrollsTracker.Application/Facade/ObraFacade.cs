using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Interfaces.Facade;
using ScrollsTracker.Domain.Interfaces.Repository;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Application.Facade
{
	public class ObraFacade : IObraFacade
	{
		private readonly IObraRepository _repo;
		private readonly IObraAggregatorService _obraAggregator;

		public ObraFacade(IObraRepository repo, IObraAggregatorService obraAggregator)
		{
			_repo = repo;
			_obraAggregator = obraAggregator;
		}

		public Task<Obra> BuscarObraAgregadaAsync(string titulo) => _obraAggregator.BuscarObraAgregadaAsync(titulo);

		public Task<int> DeleteObraById(int id) => _repo.DeleteObraByIdAsync(id);

		public Task<Obra?> GetObraByIdAsync(int id) => _repo.GetObraByIdAsync(id);

		public Task<List<Obra>> ObterLancamentosAsync() => _repo.ObterLancamentosAsync();

		public Task<List<Obra>> ObterTodasObrasAsync() => _repo.ObterTodasObrasAsync();

		public Task<int> UpdateObra(Obra obra) => _repo.UpdateObraAsync(obra);
	}
}
