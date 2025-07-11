using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Infra.Repository.Interface
{
    public interface IObraRepository
    {
        IList<Obra> ObterObras();
        Task<int> AddAsync(Obra obra);
    }
}
