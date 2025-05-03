using System;
using System.Collections.Generic;
using System.Linq;
using Viajajunto.DTOs;
using Viajajunto.Models;
using Viajajunto.Data;

namespace Viajajunto.Services
{
    public class PostImageService
    {
        private readonly ApplicationDbContext _context;

        public PostImageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public PostImageResponseDTO CreatePostImage(CreatePostImageDTO dto)
        {
            var postImage = new PostImage(dto.PostId, dto.ImageUrl);

            _context.PostImages.Add(postImage);
            _context.SaveChanges();

            return new PostImageResponseDTO
            {
                Id = postImage.Id,
                ImageUrl = postImage.ImageUrl,
                UploadedAt = postImage.UploadedAt
            };
        }

        public List<PostImageResponseDTO> GetImagesByPostId(int postId)
        {
            return _context.PostImages
                .Where(img => img.PostId == postId)
                .Select(img => new PostImageResponseDTO
                {
                    Id = img.Id,
                    PostId = img.PostId,
                    ImageUrl = img.ImageUrl,
                    UploadedAt = img.UploadedAt
                })
                .ToList();
        }
    }
}