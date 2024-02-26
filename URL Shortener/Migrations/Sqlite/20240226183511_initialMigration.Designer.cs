﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URL_Shortener.ApplicationDbContexts;

#nullable disable

namespace URL_Shortener.Migrations.Sqlite
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240226183511_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("URL_Shortener.Entities.ShortenedUrl", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("LongUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("ShortenedUrls");
                });
#pragma warning restore 612, 618
        }
    }
}