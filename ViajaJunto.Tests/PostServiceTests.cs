using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Viajajunto.Data;
using Viajajunto.DTOs;
using Viajajunto.Services;
using Xunit;

namespace Viajajunto.Tests.Services
{
    public class PostServiceTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Novo banco para testar
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void CreatePost_ShouldAddPostToDatabase()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new PostService(context);
            var dto = new CreatePostDTO
            {
                MarkPointId = 1,
                UserId = 42,
                Content = "Primeiro post de teste"
            };

            // Act
            var result = service.CreatePost(dto);

            // Assert
            var postInDb = context.Posts.FirstOrDefault();
            Assert.NotNull(postInDb);
            Assert.Equal(dto.Content, postInDb.Content);
            Assert.Equal(result.Content, postInDb.Content);
        }

        [Fact]
        public void GetAllPost_ShouldReturnAllPosts()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Posts.Add(new Models.Post(1, 1, "Post 1"));
            context.Posts.Add(new Models.Post(2, 1, "Post 2"));
            context.SaveChanges();

            var service = new PostService(context);

            // Act
            var posts = service.GetAllPosts();

            // Assert
            Assert.Equal(2, posts.Count);
            Assert.Contains(posts, p => p.Content == "Post 1");
            Assert.Contains(posts, p => p.Content == "Post 2");
        }
    }
}