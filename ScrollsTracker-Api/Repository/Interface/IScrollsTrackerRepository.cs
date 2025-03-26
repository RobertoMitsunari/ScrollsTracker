using ScrollsTracker.Api.Model;

namespace ScrollsTracker.Api.Repository.Interface
{
    public interface IScrollsTrackerRepository
    {
        IList<Obra> ObterObras();
        Task<int> CadastrarObrasAsync(Obra obra);
    }
}
