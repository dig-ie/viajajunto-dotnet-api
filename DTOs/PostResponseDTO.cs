using System;

namespace Viajajunto.DTOs
{
    public class PostResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
