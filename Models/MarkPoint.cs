using System;

namespace Viajajunto.Models
{
    public class MarkPoint
    {
        public int Id { get; private set; }
        public int ItineraryId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public int OrderIndex { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public MarkPoint(int itineraryId, string name, string description, decimal latitude, decimal longitude, int orderIndex)
        {
            ItineraryId = itineraryId;
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            OrderIndex = orderIndex;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
