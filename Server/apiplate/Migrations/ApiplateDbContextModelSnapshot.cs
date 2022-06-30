﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiplate.DataBase;

namespace apiplate.Migrations
{
    [DbContext(typeof(ApiplateDbContext))]
    partial class ApiplateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            CreatedAt = new DateTime(2022, 6, 30, 16, 10, 38, 540, DateTimeKind.Local).AddTicks(6747),
                            Email = "almunzir99@gmail.com",
                            IsManager = true,
                            LastUpdate = new DateTime(2022, 6, 30, 16, 10, 38, 541, DateTimeKind.Local).AddTicks(7210),
                            PasswordHash = new byte[] { 79, 57, 49, 217, 221, 35, 13, 31, 171, 208, 171, 157, 73, 35, 63, 229, 189, 149, 90, 52, 227, 223, 135, 58, 20, 144, 11, 89, 123, 173, 207, 113, 54, 107, 74, 12, 118, 112, 170, 255, 75, 234, 212, 216, 33, 97, 0, 211, 58, 14, 119, 118, 217, 128, 50, 37, 111, 201, 149, 110, 43, 168, 132, 208 },
                            PasswordSalt = new byte[] { 201, 48, 26, 209, 91, 95, 107, 137, 152, 198, 3, 114, 146, 230, 98, 45, 249, 87, 203, 250, 239, 141, 142, 122, 250, 248, 85, 202, 183, 170, 132, 234, 103, 106, 187, 8, 34, 176, 217, 40, 200, 212, 207, 10, 135, 61, 125, 116, 69, 147, 157, 138, 65, 226, 58, 20, 11, 164, 219, 140, 75, 43, 119, 30, 51, 211, 75, 75, 122, 46, 110, 203, 133, 77, 4, 18, 181, 112, 67, 79, 149, 130, 139, 72, 186, 45, 187, 252, 181, 244, 138, 244, 87, 163, 234, 116, 75, 254, 161, 118, 214, 193, 143, 165, 36, 179, 105, 66, 105, 224, 193, 58, 181, 251, 134, 241, 152, 36, 86, 105, 117, 220, 36, 124, 122, 19, 158, 141 },
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

            modelBuilder.Entity("apiplate.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LogoId")
                        .HasColumnType("int");

                    b.Property<int>("NameId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LogoId")
                        .IsUnique();

                    b.HasIndex("NameId")
                        .IsUnique();

                    b.ToTable("Partners");
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

                    b.Property<int?>("PartnersPermissionsId")
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

                    b.HasIndex("PartnersPermissionsId");

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

            modelBuilder.Entity("apiplate.Models.Partner", b =>
                {
                    b.HasOne("apiplate.Models.Image", "Logo")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Partner", "LogoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Name")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Partner", "NameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Logo");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("apiplate.Models.Region", b =>
                {
                    b.HasOne("apiplate.Models.Translation", "Description")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Region", "DescriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Region", "ImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Region", "TitleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Description");

                    b.Navigation("Image");

                    b.Navigation("Title");
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

                    b.HasOne("apiplate.Models.Permission", "PartnersPermissions")
                        .WithMany()
                        .HasForeignKey("PartnersPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "RegionsPermissions")
                        .WithMany()
                        .HasForeignKey("RegionsPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "RolesPermissions")
                        .WithMany()
                        .HasForeignKey("RolesPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "SectorsPermissions")
                        .WithMany()
                        .HasForeignKey("SectorsPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "SlidersPermissions")
                        .WithMany()
                        .HasForeignKey("SlidersPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Permission", "TeamPermissions")
                        .WithMany()
                        .HasForeignKey("TeamPermissionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AdminsPermissions");

                    b.Navigation("ArticlesPermissions");

                    b.Navigation("MessagesPermissions");

                    b.Navigation("PartnersPermissions");

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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Icon")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Sector", "IconId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Sector", "ImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Sector", "TitleId")
                        .OnDelete(DeleteBehavior.Restrict)
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Slider", "ImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Subtitle")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Slider", "SubtitleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Title")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Slider", "TitleId")
                        .OnDelete(DeleteBehavior.Restrict)
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
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("apiplate.Models.Translation", "Translation")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Tag", "TranslationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Translation");
                });

            modelBuilder.Entity("apiplate.Models.Team", b =>
                {
                    b.HasOne("apiplate.Models.Image", "Image")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Team", "ImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Name")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Team", "NameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiplate.Models.Translation", "Position")
                        .WithOne()
                        .HasForeignKey("apiplate.Models.Team", "PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
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
