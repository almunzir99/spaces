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










    }
}