using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Infra.Repository.Interface
{
    public interface IScrollsTrackerRepository
    {
        IList<Obra> ObterObras();
        Task<int> CadastrarObrasAsync(Obra obra);
    }
}
