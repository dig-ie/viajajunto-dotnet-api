using Viajajunto.Models;
namespace Viajajunto.Models {
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Usuário";
        public string Username { get; set; } = "default_username";
        public string Email { get; set; } = "email@exemplo.com";
        public string Password { get; set; } = "123456";


        public User() { } // Necessário para EF e testes

        public User(string name)
        {
            Name = name;
        }

        private readonly List<Itinerary> _itineraries = new();
        public IReadOnlyCollection<Itinerary> Itineraries => _itineraries.AsReadOnly();

        private readonly List<Post> _posts = new();
        public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
    }
}

