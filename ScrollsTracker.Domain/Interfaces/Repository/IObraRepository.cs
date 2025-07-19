using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Domain.Interfaces.Repository
{
    public interface IObraRepository
    {
		Task<List<Obra>> ObterTodasObrasAsync();
		Task<List<Obra>> ObterTodasObrasParaAtualizarAsync();
		Task<List<Obra>> ObterLancamentosAsync();
		Task<int> AddAsync(Obra obra);
		Task<Obra?> GetObraByIdAsync(int id);
		Task<int> UpdateObraAsync(Obra obra);
		Task<int> DeleteObraByIdAsync(int id);
	}
}
