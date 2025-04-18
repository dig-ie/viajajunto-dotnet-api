using System;
using System.Collections.Generic;

namespace Viajajunto.Models
{
    public class Itinerary
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsPublic { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private List<MarkPoint> _markPoints;
        public IReadOnlyCollection<MarkPoint> MarkPoints => _markPoints.AsReadOnly();

        public Itinerary(int userId, string title, string description, bool isPublic)
        {
            UserId = userId;
            Title = title;
            Description = description;
            IsPublic = isPublic;
            CreatedAt = DateTime.UtcNow;
            _markPoints = new List<MarkPoint>();
        }
    }
}
