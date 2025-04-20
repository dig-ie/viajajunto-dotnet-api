using System;

namespace Viajajunto.Models
{
    public class PostImage
    {
        public int Id { get; private set; }
        public int PostId { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime UploadedAt { get; private set; }

        public Post? Post { get; private set; }

        public PostImage(int postId, string imageUrl)
        {
            PostId = postId;
            ImageUrl = imageUrl;
            UploadedAt = DateTime.UtcNow;
        }
    }
}
