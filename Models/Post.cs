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

        public MarkPoint? MarkPoint { get; private set; }
        public User? User { get; private set; }

        //private readonly List<PostImage> _postImages = new();
        //public IReadOnlyCollection<PostImage> PostImages => _postImages.AsReadOnly();

        //private readonly List<PostLike> _postLikes = new();
        //public IReadOnlyCollection<PostLike> PostLikes => _postLikes.AsReadOnly();

        //private readonly List<PostComment> _postComments = new();
        //public IReadOnlyCollection<PostComment> PostComments => _postComments.AsReadOnly();

        //private readonly List<PostShare> _postShares = new();
        //public IReadOnlyCollection<PostShare> PostShares => _postShares.AsReadOnly();

        //private readonly List<PostTag> _postTags = new();
        //public IReadOnlyCollection<PostTag> PostTags => _postTags.AsReadOnly();

        // Construtor
        public Post(int markPointId, int userId, string content)
        {
            MarkPointId = markPointId;
            UserId = userId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        // Métodos para adicionar itens às coleções
        //public void AddPostImage(PostImage image) => _postImages.Add(image);
        //public void AddPostLike(PostLike like) => _postLikes.Add(like);
        //public void AddPostComment(PostComment comment) => _postComments.Add(comment);
        //public void AddPostShare(PostShare share) => _postShares.Add(share);
        //public void AddPostTag(PostTag tag) => _postTags.Add(tag);
    }
}
