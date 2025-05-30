using System;
using System.Collections.Generic;
using System.Linq;
using Viajajunto.DTOs;
using Viajajunto.Models;
using Viajajunto.Data;

namespace Viajajunto.Services
{
    public class PostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public PostResponseDTO CreatePost(CreatePostDTO dto)
        {
            var post = new Post(dto.MarkPointId, dto.UserId, dto.Content);

            _context.Posts.Add(post);
            _context.SaveChanges();

            return new PostResponseDTO(post.Id, post.Content, post.CreatedAt);
        }

        public List<PostResponseDTO> GetAllPosts()
        {
            return _context.Posts
                .Select(p => new PostResponseDTO(p.Id, p.Content, p.CreatedAt))
                .ToList();
        }
    }
}
