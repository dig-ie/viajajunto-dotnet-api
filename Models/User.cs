using Viajajunto.Models;
namespace Viajajunto.Models {
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }


        public User() { } // Necessário para EF e testes

        public User(string name, string username, string email, string password)
        {
            Name = name;
            Username = name;
            Email = email;
            Password = password;
        }

        public User(int id, string name, string username, string email, string password)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Password = password;
        }

        private readonly List<Itinerary> _itineraries = new();
        public IReadOnlyCollection<Itinerary> Itineraries => _itineraries.AsReadOnly();

        private readonly List<Post> _posts = new();
        public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
    }
}

