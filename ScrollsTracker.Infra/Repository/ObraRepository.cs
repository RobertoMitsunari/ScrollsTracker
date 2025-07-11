using ScrollsTracker.Domain.Models;
using ScrollsTracker.Infra.Repository.Context;
using ScrollsTracker.Infra.Repository.Interface;

namespace ScrollsTracker.Api.Repository
{
    public class ObraRepository : IObraRepository
    {
        private readonly AppDbContext _context;

        public ObraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Obra obra)
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
