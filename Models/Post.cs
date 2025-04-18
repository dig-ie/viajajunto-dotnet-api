using System;
using System.Collections.Generic;

namespace Viajajunto.Models
{
    public class Post
    {
        public int Id { get; private set; }
        public int MarkPointId { get; private set; }
        public int UserId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private List<PostImage> _postImages;
        public IReadOnlyCollection<PostImage> PostImages => _postImages.AsReadOnly();

        private List<PostLike> _postLikes;
        public IReadOnlyCollection<PostLike> PostLikes => _postLikes.AsReadOnly();

        private List<PostComment> _postComments;
        public IReadOnlyCollection<PostComment> PostComments => _postComments.AsReadOnly();

        private List<PostShare> _postShares;
        public IReadOnlyCollection<PostShare> PostShares => _postShares.AsReadOnly();

        public Post(int markPointId, int userId, string content)
        {
            MarkPointId = markPointId;
            UserId = userId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            _postImages = new List<PostImage>();
            _postLikes = new List<PostLike>();
            _postComments = new List<PostComment>();
            _postShares = new List<PostShare>();
        }
    }
}
