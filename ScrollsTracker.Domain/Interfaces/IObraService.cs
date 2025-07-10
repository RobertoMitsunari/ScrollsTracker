using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Domain.Interfaces
{
    public interface IObraService
    {
		IList<Obra> ObterObras();
		Task<int> CadastrarObrasAsync(Obra obra);
	}
}
