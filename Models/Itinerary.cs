using System.Collections.Generic;

namespace Viajajunto.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navegação para o usuário criador
        public virtual User User { get; set; }

        // Coleção de pontos de interesse (MarkPoints) com encapsulamento forte
        private readonly List<MarkPoint> _markPoints = new();
        public IReadOnlyCollection<MarkPoint> MarkPoints => _markPoints.AsReadOnly();
        
        
        public Itinerary()
        {
            CreatedAt = DateTime.UtcNow;
        }

        // Método para adicionar um novo ponto de interesse
        public void AddMarkPoint(MarkPoint markPoint)
        {
            if (markPoint == null)
                throw new ArgumentNullException(nameof(markPoint));
                       
            _markPoints.Add(markPoint);
        }

        // Método para remover um ponto de interesse
        public bool RemoveMarkPoint(int markPointId)
        {
            var markPoint = _markPoints.FirstOrDefault(mp => mp.Id == markPointId);
            if (markPoint != null)
            {
                return _markPoints.Remove(markPoint);
            }
            return false;
        }
        
    }
}
