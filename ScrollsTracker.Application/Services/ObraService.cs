using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Models;
using ScrollsTracker.Infra.Repository.Interface;

namespace ScrollsTracker.Application.Services
{
	public class ObraService : IObraService
	{
		private readonly IObraRepository _repo;

		public ObraService(IObraRepository repo)
		{
			_repo = repo;
		}

		public Task<int> CadastrarObrasAsync(Obra obra) => _repo.AddAsync(obra);

		public IList<Obra> ObterObras() => _repo.ObterObras();
	}
}
