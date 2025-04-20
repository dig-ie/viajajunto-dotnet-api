using System.Collections.Generic;

namespace Viajajunto.Models
{
    public class Itinerary
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Title { get; private set; }

        public User? User { get; private set; }

        private readonly List<MarkPoint> _markPoints = new();
        public IReadOnlyCollection<MarkPoint> MarkPoints => _markPoints.AsReadOnly();

        // Construtor
        public Itinerary(int userId, string title)
        {
            UserId = userId;
            Title = title;
        }

        // Método para adicionar MarkPoint
        public void AddMarkPoint(MarkPoint markPoint) => _markPoints.Add(markPoint);

    }
}
