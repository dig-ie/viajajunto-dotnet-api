namespace Viajajunto.DTOs
{
    public class CreatePostDTO
    {
        public int MarkPointId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}