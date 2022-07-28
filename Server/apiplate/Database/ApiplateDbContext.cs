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
                relationship.DeleteBehavior = DeleteBehavior.ClientCascade;
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
            builder.Entity<Region>().HasOne<Translation>(c => c.Title).WithOne().HasForeignKey<Region>(c => c.TitleId);
            builder.Entity<Region>().HasOne<Translation>(c => c.Description).WithOne().HasForeignKey<Region>(c => c.DescriptionId);
            builder.Entity<Region>().HasOne<Image>(c => c.Image).WithOne().HasForeignKey<Region>(c => c.ImageId);
            builder.Entity<Slider>().HasOne<Translation>(c => c.Title).WithOne().HasForeignKey<Slider>(c => c.TitleId);
            builder.Entity<Slider>().HasOne<Translation>(c => c.Subtitle).WithOne().HasForeignKey<Slider>(c => c.SubtitleId);
            builder.Entity<Slider>().HasOne<Translation>(c => c.Description).WithOne().HasForeignKey<Slider>(c => c.DescriptionId);
            builder.Entity<Slider>().HasOne<Image>(c => c.Image).WithOne().HasForeignKey<Slider>(c => c.ImageId);
            builder.Entity<Team>().HasOne<Translation>(c => c.Name).WithOne().HasForeignKey<Team>(c => c.NameId);
            builder.Entity<Team>().HasOne<Translation>(c => c.Position).WithOne().HasForeignKey<Team>(c => c.PositionId);
            builder.Entity<Team>().HasOne<Image>(c => c.Image).WithOne().HasForeignKey<Team>(c => c.ImageId);
            builder.Entity<Partner>().HasOne<Translation>(c => c.Name).WithOne().HasForeignKey<Partner>(c => c.NameId);
            builder.Entity<Partner>().HasOne<Image>(c => c.Logo).WithOne().HasForeignKey<Partner>(c => c.LogoId);
            builder.Entity<Testimonial>().HasOne<Translation>(c => c.Author).WithOne().HasForeignKey<Testimonial>(c => c.AuthorId);
            builder.Entity<Testimonial>().HasOne<Translation>(c => c.Job).WithOne().HasForeignKey<Testimonial>(c => c.JobId);
            builder.Entity<Testimonial>().HasOne<Translation>(c => c.Content).WithOne().HasForeignKey<Testimonial>(c => c.ContentId);
            builder.Entity<Testimonial>().HasOne<Image>(c => c.Image).WithOne().HasForeignKey<Testimonial>(c => c.ImageId);
            builder.Entity<Project>().HasOne<Translation>(c => c.Title).WithOne().HasForeignKey<Project>(c => c.TitleId);
            builder.Entity<Project>().HasOne<Translation>(c => c.Subtitle).WithOne().HasForeignKey<Project>(c => c.SubtitleId);
            builder.Entity<Project>().HasOne<Translation>(c => c.Content).WithOne().HasForeignKey<Project>(c => c.ContentId);
            builder.Entity<Project>().HasOne<Image>(c => c.Image).WithOne().HasForeignKey<Project>(c => c.ImageId);
            builder.Entity<Sector>().HasMany<Project>(c => c.Projects).WithOne(c => c.Sector).HasForeignKey(c => c.SectorId);
            builder.Entity<Region>().HasMany<Project>(c => c.Projects).WithOne(c => c.Region).HasForeignKey(c => c.RegionId);

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
        public DbSet<ArticleBase> ArticleBase { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Volunteer> volunteers { get; set; }

        

















    }
}