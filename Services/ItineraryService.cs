using Viajajunto.Models;
using Microsoft.EntityFrameworkCore;
using Viajajunto.Data;
namespace Viajajunto.Services
{
    public class ItineraryService
    {
        private readonly ApplicationDbContext _context;

        public ItineraryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Criar um novo itinerário
        public async Task<Itinerary> CreateItineraryAsync(Itinerary itinerary)
        {
            _context.Itineraries.Add(itinerary);
            await _context.SaveChangesAsync();
            return itinerary;
        }

        // Buscar itinerário por ID
        public async Task<Itinerary> GetItineraryByIdAsync(int id)
        {
            var itinerary = await _context.Itineraries
                .Include(i => i.MarkPoints)
                .Include(i => i.User)  // Inclui o usuário criador
                .FirstOrDefaultAsync(i => i.Id == id);

            return itinerary;
        }

        // Listar itinerários (próprios e públicos)
        public async Task<List<Itinerary>> ListItinerariesAsync(int userId, string searchTerm = null)
        {
            var query = _context.Itineraries
                .Include(i => i.User)
                .Where(i => i.UserId == userId || i.IsPublic);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(i => i.Title.Contains(searchTerm) || i.Description.Contains(searchTerm));
            }

            return await query.ToListAsync();
        }

        // Atualizar itinerário
        public async Task<Itinerary> UpdateItineraryAsync(Itinerary updatedData)
        {
            var existingItinerary = await _context.Itineraries
                .FirstOrDefaultAsync(i => i.Id == updatedData.Id);

            if (existingItinerary == null)
                throw new KeyNotFoundException("Itinerário não encontrado.");

            existingItinerary.Title = updatedData.Title;
            existingItinerary.Description = updatedData.Description;
            existingItinerary.IsPublic = updatedData.IsPublic;

            await _context.SaveChangesAsync();
            return existingItinerary;
        }

        // Deletar itinerário
        public async Task DeleteItineraryAsync(int id)
        {
            var itinerary = await _context.Itineraries.FindAsync(id);

            if (itinerary == null)
                throw new KeyNotFoundException("Itinerário não encontrado.");

            _context.Itineraries.Remove(itinerary);
            await _context.SaveChangesAsync();
        }

        // Adicionar ponto de interesse
        public async Task<MarkPoint> AddMarkPointAsync(MarkPoint markPoint)
        {
            var itinerary = await _context.Itineraries
                .Include(i => i.MarkPoints)
                .FirstOrDefaultAsync(i => i.Id == markPoint.ItineraryId);

            if (itinerary == null)
                throw new KeyNotFoundException("Itinerário não encontrado.");

            itinerary.AddMarkPoint(markPoint);
            await _context.SaveChangesAsync();
            return markPoint;
        }

        // Remover ponto de interesse
        public async Task RemoveMarkPointAsync(int itineraryId, int markPointId)
        {
            var itinerary = await _context.Itineraries
                .Include(i => i.MarkPoints)
                .FirstOrDefaultAsync(i => i.Id == itineraryId);

            if (itinerary == null)
                throw new KeyNotFoundException("Itinerário não encontrado.");

            bool removed = itinerary.RemoveMarkPoint(markPointId);
            if (!removed)
                throw new KeyNotFoundException("Ponto de interesse não encontrado neste itinerário.");

            await _context.SaveChangesAsync();
        }
    }
}
