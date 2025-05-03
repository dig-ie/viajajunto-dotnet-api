using System;

namespace Viajajunto.DTOs
{
    public class PostImageResponseDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }
}