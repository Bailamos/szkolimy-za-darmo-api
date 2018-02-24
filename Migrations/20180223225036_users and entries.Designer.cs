﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;
using Szkolimy_za_darmo_api.Persistance;

namespace Szkolimyzadarmoapi.Migrations
{
    [DbContext(typeof(SzdDbContext))]
    [Migration("20180223225036_users and entries")]
    partial class usersandentries
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Category", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Name");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Entry", b =>
                {
                    b.Property<int>("TrainingId");

                    b.Property<string>("UserPhoneNumber");

                    b.HasKey("TrainingId", "UserPhoneNumber");

                    b.HasIndex("UserPhoneNumber");

                    b.ToTable("entries");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Localization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("voivodeship");

                    b.HasKey("Id");

                    b.ToTable("localizations");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.MarketStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Status")
                        .IsUnique();

                    b.ToTable("marketStatuses");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Name");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("InsertDate");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("LocalizationId");

                    b.Property<int>("MarketStatusId");

                    b.Property<DateTime>("RegisterSince");

                    b.Property<DateTime>("RegisterTo");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CategoryName");

                    b.HasIndex("LocalizationId");

                    b.HasIndex("MarketStatusId");

                    b.ToTable("trainings");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.TrainingTag", b =>
                {
                    b.Property<int>("TrainingId");

                    b.Property<string>("TagName");

                    b.HasKey("TrainingId", "TagName");

                    b.HasIndex("TagName");

                    b.ToTable("training_tags");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.User", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("PhoneNumber");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Entry", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Training", "Training")
                        .WithMany("Entries")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.User", "user")
                        .WithMany("Entries")
                        .HasForeignKey("UserPhoneNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Training", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Localization", "Localization")
                        .WithMany()
                        .HasForeignKey("LocalizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.MarketStatus", "MarketStatus")
                        .WithMany()
                        .HasForeignKey("MarketStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.TrainingTag", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Training", "Training")
                        .WithMany("Tags")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
