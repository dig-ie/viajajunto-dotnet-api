using Microsoft.EntityFrameworkCore;
using Viajajunto.Models;

namespace Viajajunto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets para as entidades (tabelas no banco de dados)
        public DbSet<User> Users { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<MarkPoint> MarkPoints { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        //public DbSet<PostLike> PostLikes { get; set; }
        //public DbSet<PostComment> PostComments { get; set; }
        //public DbSet<PostShare> PostShares { get; set; }
        //public DbSet<Notification> Notifications { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        //public DbSet<PostTag> PostTags { get; set; }
        //public DbSet<Friendship> Friendships { get; set; }
        //public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamentos padr�o
            modelBuilder.Entity<Itinerary>()
                .HasOne(i => i.User)
                .WithMany(u => u.Itineraries)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MarkPoint>()
                .HasOne(mp => mp.Itinerary)
                .WithMany(i => i.MarkPoints)
                .HasForeignKey(mp => mp.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.MarkPoint)
                .WithMany(mp => mp.Posts)
                .HasForeignKey(p => p.MarkPointId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostImage>()
            //    .HasOne(pi => pi.Post)
            //    .WithMany(p => p.PostImages)
            //    .HasForeignKey(pi => pi.PostId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostLike>()
            //    .HasOne(pl => pl.Post)
            //    .WithMany(p => p.PostLikes)
            //    .HasForeignKey(pl => pl.PostId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostLike>()
            //    .HasOne(pl => pl.User)
            //    .WithMany(u => u.PostLikes)
            //    .HasForeignKey(pl => pl.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostComment>()
            //    .HasOne(pc => pc.Post)
            //    .WithMany(p => p.PostComments)
            //    .HasForeignKey(pc => pc.PostId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostComment>()
            //    .HasOne(pc => pc.User)
            //    .WithMany(u => u.PostComments)
            //    .HasForeignKey(pc => pc.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostShare>()
            //    .HasOne(ps => ps.Post)
            //    .WithMany(p => p.PostShares)
            //    .HasForeignKey(ps => ps.PostId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostShare>()
            //    .HasOne(ps => ps.User)
            //    .WithMany(u => u.PostShares)
            //    .HasForeignKey(ps => ps.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Notification>()
            //    .HasOne(n => n.User)
            //    .WithMany(u => u.Notifications)
            //    .HasForeignKey(n => n.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PostTag>()
            //    .HasKey(pt => new { pt.PostId, pt.TagId });

            //modelBuilder.Entity<PostTag>()
            //    .HasOne(pt => pt.Post)
            //    .WithMany(p => p.PostTags)
            //    .HasForeignKey(pt => pt.PostId);

            //modelBuilder.Entity<PostTag>()
            //    .HasOne(pt => pt.Tag)
            //    .WithMany(t => t.PostTags)
            //    .HasForeignKey(pt => pt.TagId);

            //modelBuilder.Entity<Friendship>()
            //    .HasOne(f => f.UserRequester)
            //    .WithMany(u => u.FriendshipsRequested)
            //    .HasForeignKey(f => f.UserRequesterId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Friendship>()
            //    .HasOne(f => f.UserReceiver)
            //    .WithMany(u => u.FriendshipsReceived)
            //    .HasForeignKey(f => f.UserReceiverId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Message>()
            //    .HasOne(m => m.Sender)
            //    .WithMany(u => u.MessagesSent)
            //    .HasForeignKey(m => m.SenderId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Message>()
            //    .HasOne(m => m.Receiver)
            //    .WithMany(u => u.MessagesReceived)
            //    .HasForeignKey(m => m.ReceiverId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Configura��es de acesso para cole��es privadas (caso use campos em vez de propriedades p�blicas)
            //modelBuilder.Entity<Post>().Navigation(p => p.PostImages).UsePropertyAccessMode(PropertyAccessMode.Field);
            //modelBuilder.Entity<Post>().Navigation(p => p.PostLikes).UsePropertyAccessMode(PropertyAccessMode.Field);
            //modelBuilder.Entity<Post>().Navigation(p => p.PostComments).UsePropertyAccessMode(PropertyAccessMode.Field);
            //modelBuilder.Entity<Post>().Navigation(p => p.PostShares).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
