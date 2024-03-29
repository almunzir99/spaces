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
    [Migration("20220630134352_addClientCascadeForAllTables")]
    partial class addClientCascadeForAllTables
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
                            CreatedAt = new DateTime(2022, 6, 30, 15, 43, 52, 19, DateTimeKind.Local).AddTicks(181),
                            Email = "almunzir99@gmail.com",
                            IsManager = true,
                            LastUpdate = new DateTime(2022, 6, 30, 15, 43, 52, 21, DateTimeKind.Local).AddTicks(1516),
                            PasswordHash = new byte[] { 77, 37, 72, 78, 142, 35, 246, 118, 43, 110, 51, 250, 153, 176, 168, 130, 50, 246, 3, 30, 151, 173, 211, 81, 8, 169, 178, 88, 254, 245, 89, 121, 109, 159, 132, 110, 211, 41, 174, 182, 242, 231, 61, 113, 252, 102, 206, 18, 184, 168, 121, 211, 235, 250, 188, 63, 165, 20, 105, 236, 9, 33, 146, 141 },
                            PasswordSalt = new byte[] { 68, 246, 59, 235, 239, 141, 249, 73, 243, 248, 158, 8, 114, 161, 205, 172, 203, 130, 55, 253, 193, 92, 13, 192, 211, 247, 221, 175, 17, 153, 46, 54, 115, 127, 158, 198, 76, 65, 132, 7, 42, 108, 57, 4, 159, 216, 111, 249, 109, 40, 7, 79, 90, 173, 246, 117, 39, 201, 109, 78, 121, 196, 203, 75, 210, 239, 123, 47, 36, 149, 78, 122, 212, 2, 224, 245, 218, 39, 243, 211, 1, 164, 223, 221, 247, 99, 240, 164, 145, 57, 224, 83, 144, 4, 208, 72, 210, 40, 101, 76, 75, 159, 95, 239, 233, 93, 218, 105, 160, 177, 12, 201, 180, 26, 136, 207, 64, 152, 235, 12, 46, 242, 60, 240, 50, 118, 231, 126 },
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

            modelBuilder.Entity("apiplate.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("TitleId")
                        .IsUnique();

                    b.ToTable("Regions");
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

                    b.Property<int?>("RegionsPermissionsId")
                        .HasColumnType("int");

                    b.Property<int?>("RolesPermissionsId")
                        .HasColumnType("int");

                    b.Property<int?>("SectorsPermissionsId")
                        .HasColumnType("int");

                    b.Property<int?>("SlidersPermissionsId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamPermissionsId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AdminsPermissionsId");

                    b.HasIndex("ArticlesPermissionsId");

                    b.HasIndex("MessagesPermissionsId");

                    b.HasIndex("RegionsPermissionsId");

                    b.HasIndex("RolesPermissionsId");

                    b.HasIndex("SectorsPermissionsId");

                    b.HasIndex("SlidersPermissionsId");

                    b.HasIndex("TeamPermissionsId");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasFilter("[Title] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("apiplate.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<int>("IconId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.HasIndex("IconId")
                        .IsUnique();

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("TitleId")
                        .IsUnique();

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("apiplate.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubtitleId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("SubtitleId")
                        .IsUnique();

                    b.HasIndex("TitleId")
                        .IsUnique();

                    b.ToTable("Sliders");
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

            modelBuilder.Entity("apiplate.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Instgram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NameId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("NameId")
                        .IsUnique();

                    b.HasIndex("PositionId")
                        .IsUnique();

                    b.ToTable("Team");
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
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("apiplate.Models.Admin", b =>
                {
                    b.HasOne("apiplate.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("apiplate.Models.Article", b =>
                {
                    b.HasOne("apiplate.Models.Admin", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Content")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "ContentId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "ImageId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Subtitle")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "SubtitleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Article", "TitleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
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
                        .HasForeignKey("ArticleId");
                });

            modelBuilder.Entity("apiplate.Models.Notification", b =>
                {
                    b.HasOne("apiplate.Models.Admin", null)
                        .WithMany("Notifications")
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("apiplate.Models.Region", b =>
                {
                    b.HasOne("apiplate.Models.Translation", "Description")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Region", "DescriptionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Region", "ImageId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Region", "TitleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Description");

                    b.Navigation("Image");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("apiplate.Models.Role", b =>
                {
                    b.HasOne("apiplate.Models.Permission", "AdminsPermissions")
                        .WithMany()
                        .HasForeignKey("AdminsPermissionsId");

                    b.HasOne("apiplate.Models.Permission", "ArticlesPermissions")
                        .WithMany()
                        .HasForeignKey("ArticlesPermissionsId");

                    b.HasOne("apiplate.Models.Permission", "MessagesPermissions")
                        .WithMany()
                        .HasForeignKey("MessagesPermissionsId");

                    b.HasOne("apiplate.Models.Permission", "RegionsPermissions")
                        .WithMany()
                        .HasForeignKey("RegionsPermissionsId");

                    b.HasOne("apiplate.Models.Permission", "RolesPermissions")
                        .WithMany()
                        .HasForeignKey("RolesPermissionsId");

                    b.HasOne("apiplate.Models.Permission", "SectorsPermissions")
                        .WithMany()
                        .HasForeignKey("SectorsPermissionsId");

                    b.HasOne("apiplate.Models.Permission", "SlidersPermissions")
                        .WithMany()
                        .HasForeignKey("SlidersPermissionsId");

                    b.HasOne("apiplate.Models.Permission", "TeamPermissions")
                        .WithMany()
                        .HasForeignKey("TeamPermissionsId");

                    b.Navigation("AdminsPermissions");

                    b.Navigation("ArticlesPermissions");

                    b.Navigation("MessagesPermissions");

                    b.Navigation("RegionsPermissions");

                    b.Navigation("RolesPermissions");

                    b.Navigation("SectorsPermissions");

                    b.Navigation("SlidersPermissions");

                    b.Navigation("TeamPermissions");
                });

            modelBuilder.Entity("apiplate.Models.Sector", b =>
                {
                    b.HasOne("apiplate.Models.Translation", "Description")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Sector", "DescriptionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Icon")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Sector", "IconId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Sector", "ImageId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Sector", "TitleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Description");

                    b.Navigation("Icon");

                    b.Navigation("Image");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("apiplate.Models.Slider", b =>
                {
                    b.HasOne("apiplate.Models.Translation", "Description")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Slider", "DescriptionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Slider", "ImageId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Subtitle")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Slider", "SubtitleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Slider", "TitleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Description");

                    b.Navigation("Image");

                    b.Navigation("Subtitle");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("apiplate.Models.Tag", b =>
                {
                    b.HasOne("apiplate.Models.Article", null)
                        .WithMany("Tags")
                        .HasForeignKey("ArticleId");

                    b.HasOne("apiplate.Models.Translation", "Translation")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Tag", "TranslationId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Translation");
                });

            modelBuilder.Entity("apiplate.Models.Team", b =>
                {
                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Team", "ImageId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Name")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Team", "NameId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Position")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Team", "PositionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Name");

                    b.Navigation("Position");
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
