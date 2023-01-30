﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCharactersAPI.Models.Data;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    [DbContext(typeof(MovieCharactersDbContext))]
    partial class MovieCharactersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 3
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Domain.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"), 1L, 1);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacterId");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            Alias = "None",
                            FullName = "FullName1",
                            Gender = 0,
                            PictureURL = "Not Given"
                        },
                        new
                        {
                            CharacterId = 2,
                            Alias = "None",
                            FullName = "FullName2",
                            Gender = 0,
                            PictureURL = "Not Given"
                        },
                        new
                        {
                            CharacterId = 3,
                            Alias = "None",
                            FullName = "FullName3",
                            Gender = 0,
                            PictureURL = "Not Given"
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Domain.Franchise", b =>
                {
                    b.Property<int>("FranchiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FranchiseId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("FranchiseId");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            FranchiseId = 1,
                            Description = "Description1",
                            Name = "Franchise1"
                        },
                        new
                        {
                            FranchiseId = 2,
                            Description = "Description2",
                            Name = "Franchise2"
                        },
                        new
                        {
                            FranchiseId = 3,
                            Description = "Description3",
                            Name = "Franchise3"
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Domain.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TrailerURl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Director = "Director1",
                            FranchiseId = 1,
                            Genre = "Genre3",
                            PictureURL = "",
                            ReleaseYear = "2001",
                            Title = "Title1",
                            TrailerURl = ""
                        },
                        new
                        {
                            MovieId = 2,
                            Director = "Director2",
                            FranchiseId = 2,
                            Genre = "Genre2",
                            PictureURL = "",
                            ReleaseYear = "2002",
                            Title = "Title2",
                            TrailerURl = ""
                        },
                        new
                        {
                            MovieId = 3,
                            Director = "Director3",
                            FranchiseId = 3,
                            Genre = "Genre3",
                            PictureURL = "",
                            ReleaseYear = "2003",
                            Title = "Title3",
                            TrailerURl = ""
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCharactersAPI.Models.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Domain.Movie", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Domain.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Domain.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
