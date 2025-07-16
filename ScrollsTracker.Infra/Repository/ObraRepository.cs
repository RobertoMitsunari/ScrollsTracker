using Microsoft.EntityFrameworkCore;
using ScrollsTracker.Domain.Interfaces.Repository;
using ScrollsTracker.Domain.Models;
using ScrollsTracker.Infra.Repository.Context;

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

		public async Task<Obra?> GetObraByIdAsync(int id)
		{
			return await _context.Obras.FindAsync(id);
		}

		public async Task<int> DeleteObraByIdAsync(int id)
		{
			var obraParaDeletar = await _context.Obras.FindAsync(id);

			if (obraParaDeletar == null)
			{
				return 0;
			}

			_context.Obras.Remove(obraParaDeletar);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> UpdateObraAsync(Obra obra)
		{
			_context.Obras.Update(obra);

			return await _context.SaveChangesAsync();
		}

		public async Task<List<Obra>> ObterTodasObrasAsync()
		{
			return await _context.Obras.ToListAsync();
		}

		public async Task<List<Obra>> ObterTodasObrasParaAtualizarAsync()
		{
			var obras = await _context.Obras.ToListAsync();

			return obras.Where(obra => (DateTime.Now - obra.DataAtualizacao).Hours >= 1).ToList();
		}
	}
}