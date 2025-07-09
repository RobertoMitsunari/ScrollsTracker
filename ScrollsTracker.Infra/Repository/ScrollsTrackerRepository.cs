using ScrollsTracker.Domain.Models;
using ScrollsTracker.Infra.Repository.Context;
using ScrollsTracker.Infra.Repository.Interface;

namespace ScrollsTracker.Api.Repository
{
    public class ScrollsTrackerRepository : IScrollsTrackerRepository
    {
        private readonly AppDbContext _context;

        public ScrollsTrackerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CadastrarObrasAsync(Obra obra)
        {
            _context.Obras.Add(obra);
            return await _context.SaveChangesAsync();
        }

        public IList<Obra> ObterObras()
        {
            return _context.Obras.ToList();
        }
    }
}
