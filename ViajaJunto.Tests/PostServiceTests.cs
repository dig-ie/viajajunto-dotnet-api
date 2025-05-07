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
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void CreatePost_ShouldAddPostToDatabase()
        {
            var context = GetInMemoryDbContext();
            var service = new PostService(context);
            var dto = new CreatePostDTO(1, 42, "Primeiro post de teste");

            var result = service.CreatePost(dto);

            var postInDb = context.Posts.FirstOrDefault();
            Assert.NotNull(postInDb);
            Assert.Equal(dto.Content, postInDb.Content);
            Assert.Equal(result.Content, postInDb.Content);
        }

        [Fact]
        public void GetAllPost_ShouldReturnAllPosts()
        {
            var context = GetInMemoryDbContext();
            context.Posts.Add(new Models.Post(1, 1, "Post 1"));
            context.Posts.Add(new Models.Post(2, 1, "Post 2"));
            context.SaveChanges();

            var service = new PostService(context);

            var posts = service.GetAllPosts();

            Assert.Equal(2, posts.Count);
            Assert.Contains(posts, p => p.Content == "Post 1");
            Assert.Contains(posts, p => p.Content == "Post 2");
        }
    }
}