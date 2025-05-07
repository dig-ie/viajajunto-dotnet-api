using System;

namespace Viajajunto.DTOs
{
    public record PostImageResponseDTO(int Id, int PostId, string ImageUrl, DateTime UploadedAt);
}