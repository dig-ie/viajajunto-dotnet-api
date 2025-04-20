using System.Collections.Generic;

namespace Viajajunto.Models
{
    public class MarkPoint
    {
        public int Id { get; private set; }
        public int ItineraryId { get; private set; }
        public string Location { get; private set; }

        public Itinerary? Itinerary { get; private set; }

        private readonly List<Post> _posts = new();
        public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();

        // Construtor
        public MarkPoint(int itineraryId, string location)
        {
            ItineraryId = itineraryId;
            Location = location;
        }

        // Método para adicionar Post
        public void AddPost(Post post) => _posts.Add(post);
    }
}
