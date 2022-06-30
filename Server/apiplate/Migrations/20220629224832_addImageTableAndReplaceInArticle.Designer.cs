﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiplate.DataBase;

namespace apiplate.Migrations
{
    [DbContext(typeof(ApiplateDbContext))]
    [Migration("20220629224832_addImageTableAndReplaceInArticle")]
    partial class addImageTableAndReplaceInArticle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apiplate.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EffectedRowId")
                        .HasColumnType("int");

                    b.Property<string>("EffectedTable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("apiplate.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsManager")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 6, 30, 0, 48, 31, 804, DateTimeKind.Local).AddTicks(1983),
                            Email = "almunzir99@gmail.com",
                            IsManager = true,
                            LastUpdate = new DateTime(2022, 6, 30, 0, 48, 31, 805, DateTimeKind.Local).AddTicks(4597),
                            PasswordHash = new byte[] { 238, 122, 209, 17, 212, 62, 234, 50, 191, 92, 96, 207, 159, 168, 55, 162, 89, 217, 41, 209, 193, 76, 72, 61, 174, 222, 91, 95, 240, 154, 213, 116, 111, 125, 195, 87, 203, 70, 38, 10, 183, 86, 168, 254, 77, 226, 7, 30, 97, 97, 57, 162, 164, 124, 75, 10, 152, 153, 23, 254, 239, 118, 90, 27 },
                            PasswordSalt = new byte[] { 66, 199, 39, 251, 24, 131, 217, 151, 16, 203, 156, 227, 68, 39, 241, 219, 106, 94, 198, 35, 147, 143, 22, 14, 182, 43, 58, 89, 195, 181, 232, 69, 31, 62, 68, 249, 221, 120, 13, 125, 37, 188, 82, 65, 132, 121, 245, 243, 17, 76, 235, 203, 141, 103, 249, 57, 40, 228, 236, 47, 131, 251, 27, 62, 56, 137, 54, 142, 194, 131, 118, 36, 41, 149, 99, 162, 92, 199, 211, 175, 137, 138, 224, 85, 127, 231, 27, 77, 245, 108, 143, 226, 117, 12, 0, 44, 197, 194, 130, 85, 159, 195, 24, 211, 22, 203, 37, 113, 145, 227, 135, 219, 14, 251, 209, 66, 32, 122, 36, 186, 65, 42, 153, 143, 84, 66, 221, 45 },
                            Phone = "249128647019",
                            Username = "almunzir99"
                        });
                });

            modelBuilder.Entity("apiplate.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubtitleId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ContentId")
                        .IsUnique();

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("SubtitleId")
                        .IsUnique();

                    b.HasIndex("TitleId")
                        .IsUnique();

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("apiplate.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("apiplate.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("apiplate.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("apiplate.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("GroupedItem")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("apiplate.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Create")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("Delete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<bool>("Update")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("apiplate.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminsPermissionsId")
                        .HasColumnType("int");

                    b.Property<int?>("ArticlesPermissionsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MessagesPermissionsId")
                        .HasColumnType("int");

                    b.Property<int?>("RolesPermissionsId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AdminsPermissionsId");

                    b.HasIndex("ArticlesPermissionsId");

                    b.HasIndex("MessagesPermissionsId");

                    b.HasIndex("RolesPermissionsId");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasFilter("[Title] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("apiplate.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("TranslationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("TranslationId")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("apiplate.Models.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("apiplate.Models.Activity", b =>
                {
                    b.HasOne("apiplate.Models.Admin", null)
                        .WithMany("Activities")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("apiplate.Models.Admin", b =>
                {
                    b.HasOne("apiplate.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Role");
                });

            modelBuilder.Entity("apiplate.Models.Article", b =>
                {
                    b.HasOne("apiplate.Models.Admin", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Content")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "ContentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "ImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Subtitle")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "SubtitleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "TitleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Content");

                    b.Navigation("Image");

                    b.Navigation("Subtitle");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("apiplate.Models.Comment", b =>
                {
                    b.HasOne("apiplate.Models.Article", null)
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("apiplate.Models.Notification", b =>
                {
                    b.HasOne("apiplate.Models.Admin", null)
                        .WithMany("Notifications")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("apiplate.Models.Role", b =>
                {
                    b.HasOne("apiplate.Models.Permission", "AdminsPermissions")
                        .WithMany()
                        .HasForeignKey("AdminsPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "ArticlesPermissions")
                        .WithMany()
                        .HasForeignKey("ArticlesPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "MessagesPermissions")
                        .WithMany()
                        .HasForeignKey("MessagesPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "RolesPermissions")
                        .WithMany()
                        .HasForeignKey("RolesPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AdminsPermissions");

                    b.Navigation("ArticlesPermissions");

                    b.Navigation("MessagesPermissions");

                    b.Navigation("RolesPermissions");
                });

            modelBuilder.Entity("apiplate.Models.Tag", b =>
                {
                    b.HasOne("apiplate.Models.Article", null)
                        .WithMany("Tags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Translation", "Translation")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Tag", "TranslationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Translation");
                });

            modelBuilder.Entity("apiplate.Models.Admin", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("apiplate.Models.Article", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}