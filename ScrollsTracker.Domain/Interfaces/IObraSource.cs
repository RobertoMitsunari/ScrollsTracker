using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Domain.Interfaces
{
    public interface IObraSource
    {
        Task<Obra?> ObterObraAsync(string titulo);
        string SourceName { get; }
	}
}
