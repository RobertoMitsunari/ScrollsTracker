using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Domain.Interfaces
{
    public interface IObraAggregatorService
    {
		Task<Obra> BuscarObraAgregadaAsync(string titulo);

		Task<Obra> BuscarEAtualizaObraAsync(Obra obra);
	}
}
