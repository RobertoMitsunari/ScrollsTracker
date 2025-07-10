using ScrollsTracker.Domain.Enum;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Domain.Interfaces
{
    public interface IObraFilter
    {
		void Filtrar(Obra obra, EnumSources novaOrigem);
	}
}
