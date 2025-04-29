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

        // Criar um novo itiner�rio
        public async Task<Itinerary> CreateItineraryAsync(Itinerary itinerary)
        {
            _context.Itineraries.Add(itinerary);
            await _context.SaveChangesAsync();
            return itinerary;
        }

        // Buscar itiner�rio por ID
        public async Task<Itinerary> GetItineraryByIdAsync(int id)
        {
            var itinerary = await _context.Itineraries
                .Include(i => i.MarkPoints)
                .Include(i => i.User)  // Inclui o usu�rio criador
                .FirstOrDefaultAsync(i => i.Id == id);

            return itinerary;
        }

        // Listar itiner�rios (pr�prios e p�blicos)
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

        // Atualizar itiner�rio
        public async Task<Itinerary> UpdateItineraryAsync(Itinerary updatedData)
        {
            var existingItinerary = await _context.Itineraries
                .FirstOrDefaultAsync(i => i.Id == updatedData.Id);

            if (existingItinerary == null)
                throw new KeyNotFoundException("Itiner�rio n�o encontrado.");

            existingItinerary.Title = updatedData.Title;
            existingItinerary.Description = updatedData.Description;
            existingItinerary.IsPublic = updatedData.IsPublic;

            await _context.SaveChangesAsync();
            return existingItinerary;
        }

        // Deletar itiner�rio
        public async Task DeleteItineraryAsync(int id)
        {
            var itinerary = await _context.Itineraries.FindAsync(id);

            if (itinerary == null)
                throw new KeyNotFoundException("Itiner�rio n�o encontrado.");

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
                throw new KeyNotFoundException("Itiner�rio n�o encontrado.");

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
                throw new KeyNotFoundException("Itiner�rio n�o encontrado.");

            bool removed = itinerary.RemoveMarkPoint(markPointId);
            if (!removed)
                throw new KeyNotFoundException("Ponto de interesse n�o encontrado neste itiner�rio.");

            await _context.SaveChangesAsync();
        }
    }
}
