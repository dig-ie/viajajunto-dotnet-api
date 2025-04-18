using System;
using System.Collections.Generic;

namespace Viajajunto.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private List<Itinerary> _itineraries;
        public IReadOnlyCollection<Itinerary> Itineraries => _itineraries.AsReadOnly();

        private List<Post> _posts;
        public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();

        private List<PostLike> _postLikes;
        public IReadOnlyCollection<PostLike> PostLikes => _postLikes.AsReadOnly();

        private List<PostComment> _postComments;
        public IReadOnlyCollection<PostComment> PostComments => _postComments.AsReadOnly();

        private List<PostShare> _postShares;
        public IReadOnlyCollection<PostShare> PostShares => _postShares.AsReadOnly();

        private List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

        private List<Friendship> _friendshipsRequester;
        public IReadOnlyCollection<Friendship> FriendshipsRequester => _friendshipsRequester.AsReadOnly();

        private List<Friendship> _friendshipsReceiver;
        public IReadOnlyCollection<Friendship> FriendshipsReceiver => _friendshipsReceiver.AsReadOnly();

        private List<Message> _sentMessages;
        public IReadOnlyCollection<Message> SentMessages => _sentMessages.AsReadOnly();

        private List<Message> _receivedMessages;
        public IReadOnlyCollection<Message> ReceivedMessages => _receivedMessages.AsReadOnly();

        public User(string username, string email, string passwordHash)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
            _itineraries = new List<Itinerary>();
            _posts = new List<Post>();
            _postLikes = new List<PostLike>();
            _postComments = new List<PostComment>();
            _postShares = new List<PostShare>();
            _notifications = new List<Notification>();
            _friendshipsRequester = new List<Friendship>();
            _friendshipsReceiver = new List<Friendship>();
            _sentMessages = new List<Message>();
            _receivedMessages = new List<Message>();
        }
    }
}
