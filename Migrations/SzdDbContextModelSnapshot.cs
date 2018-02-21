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
    partial class SzdDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

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

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("MainTypeName");

                    b.Property<int>("MarketStatusId");

                    b.Property<DateTime>("RegisterSince");

                    b.Property<DateTime>("RegisterTo");

                    b.Property<string>("Title")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MainTypeName");

                    b.HasIndex("MarketStatusId");

                    b.ToTable("trainings");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.TrainingType", b =>
                {
                    b.Property<int>("TrainingId");

                    b.Property<string>("TypeName");

                    b.HasKey("TrainingId", "TypeName");

                    b.HasIndex("TypeName");

                    b.ToTable("training_types");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Type", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Name");

                    b.ToTable("types");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Training", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Type", "MainType")
                        .WithMany()
                        .HasForeignKey("MainTypeName");

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.MarketStatus", "MarketStatus")
                        .WithMany()
                        .HasForeignKey("MarketStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.TrainingType", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Training", "Training")
                        .WithMany("Types")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeName")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
