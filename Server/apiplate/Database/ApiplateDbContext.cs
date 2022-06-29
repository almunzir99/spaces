using System.Linq;
using apiplate.Models;
using apiplate.Helpers;
using Microsoft.EntityFrameworkCore;

namespace apiplate.DataBase
{
    public class ApiplateDbContext : DbContext
    {

        public ApiplateDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<Admin>().HasIndex(c => c.Email).IsUnique();
            builder.Entity<Admin>().HasData(GetManagerUser());
            builder.Entity<Role>().HasIndex(c => c.Title).IsUnique();
            builder.Entity<Article>().HasOne<Translation>(c => c.Title).WithOne().HasForeignKey<Article>(c => c.TitleId);
            builder.Entity<Article>().HasOne<Translation>(c => c.Subtitle).WithOne().HasForeignKey<Article>(c => c.SubtitleId);
            builder.Entity<Article>().HasOne<Translation>(c => c.Content).WithOne().HasForeignKey<Article>(c => c.ContentId);
            builder.Entity<Article>().HasOne<Image>(c => c.Image).WithOne().HasForeignKey<Article>(c => c.ImageId);
            builder.Entity<Sector>().HasOne<Translation>(c => c.Title).WithOne().HasForeignKey<Sector>(c => c.TitleId);
            builder.Entity<Sector>().HasOne<Translation>(c => c.Description).WithOne().HasForeignKey<Sector>(c => c.DescriptionId);
            builder.Entity<Sector>().HasOne<Image>(c => c.Image).WithOne().HasForeignKey<Sector>(c => c.ImageId);
            builder.Entity<Sector>().HasOne<Image>(c => c.Icon).WithOne().HasForeignKey<Sector>(c => c.IconId);
            builder.Entity<Tag>().HasOne<Translation>(c => c.Translation).WithOne().HasForeignKey<Tag>(c => c.TranslationId);
        }
        private Admin GetManagerUser()
        {
            byte[] pHash, pSalt;
            HashingHelper.CreateHashPassword("maze@0099", out pHash, out pSalt);
            Admin admin = new Admin()
            {
                Id = 1,
                Username = "almunzir99",
                PasswordHash = pHash,
                PasswordSalt = pSalt,
                Phone = "249128647019",
                Email = "almunzir99@gmail.com",
                IsManager = true,
                CreatedAt = System.DateTime.Now,
                LastUpdate = System.DateTime.Now


            };
            return admin;

        }
        public DbSet<Admin> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Sector> Sectors { get; set; }












    }
}