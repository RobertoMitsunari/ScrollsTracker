using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Domain.Interfaces.Facade
{
    public interface IObraFacade
    {
		Task<List<Obra>> ObterTodasObrasAsync();
		Task<Obra?> GetObraByIdAsync(int id);
		Task<int> UpdateObra(Obra obra);
		Task<int> DeleteObraById(int id);
		Task<Obra> BuscarObraAgregadaAsync(string titulo);
	}
}
