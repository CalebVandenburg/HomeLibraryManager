﻿// <auto-generated />
using System;
using HomeLibraryManager.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeLibraryManager.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("HomeLibraryManager.Database.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Authors")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EditionNotes")
                        .HasColumnType("TEXT");

                    b.Property<string>("GoogleBookId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN10")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN13")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsFirstEdition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Large")
                        .HasColumnType("TEXT");

                    b.Property<string>("Medium")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PageCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrintNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublishedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT");

                    b.Property<string>("Small")
                        .HasColumnType("TEXT");

                    b.Property<string>("SmallThumbnail")
                        .HasColumnType("TEXT");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("HomeLibraryManager.Database.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("HomeLibraryManager.Database.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HomeLibraryManager.Database.Book", b =>
                {
                    b.HasOne("HomeLibraryManager.Database.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeLibraryManager.Database.Review", b =>
                {
                    b.HasOne("HomeLibraryManager.Database.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("HomeLibraryManager.Database.Book", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("HomeLibraryManager.Database.User", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
