using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Viajajunto.Data;
using Viajajunto.DTOs;
using Viajajunto.Models;
using Viajajunto.Services;
using Xunit;

namespace Viajajunto.Tests.Services
{
    public class PostImageServiceTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void CreatePostImage_ShouldAddImageToDatabase()
        {
            var context = GetInMemoryDbContext();

            var post = new Post(1, 1, "Post de teste");
            context.Posts.Add(post);
            context.SaveChanges();

            var service = new PostImageService(context);
            var dto = new CreatePostImageDTO(post.Id, "https://exemplo.com/imagem.jpg");

            var result = service.CreatePostImage(dto);

            var imageInDb = context.PostImages.FirstOrDefault();
            Assert.NotNull(imageInDb);
            Assert.Equal(dto.ImageUrl, imageInDb.ImageUrl);
            Assert.Equal(dto.PostId, imageInDb.PostId);
            Assert.Equal(result.ImageUrl, imageInDb.ImageUrl);
        }

        [Fact]
        public void GetImagesByPostId_ShouldReturnCorrectImages()
        {
            var context = GetInMemoryDbContext();
            var post = new Post(1, 1, "Post com imagens");
            context.Posts.Add(post);
            context.SaveChanges();

            var img1 = new PostImage(post.Id, "https://exemplo.com/1.jpg");
            var img2 = new PostImage(post.Id, "https://exemplo.com/2.jpg");
            var imgOther = new PostImage(999, "https://exemplo.com/outra.jpg");

            context.PostImages.AddRange(img1, img2, imgOther);
            context.SaveChanges();

            var service = new PostImageService(context);

            var images = service.GetImagesByPostId(post.Id);

            Assert.Equal(2, images.Count);
            Assert.All(images, img => Assert.Equal(post.Id, img.PostId));
        }
    }
}
