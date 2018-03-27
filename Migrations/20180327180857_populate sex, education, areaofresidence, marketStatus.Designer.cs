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
    [Migration("20180327180857_populate sex, education, areaofresidence, marketStatus")]
    partial class populatesexeducationareaofresidencemarketStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.AreaOfResidence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaType")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("areas_of_residence");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Category", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Name");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EducationType")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("educations");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Entry", b =>
                {
                    b.Property<int>("TrainingId");

                    b.Property<string>("UserPhoneNumber");

                    b.Property<DateTime>("InsertDate");

                    b.HasKey("TrainingId", "UserPhoneNumber");

                    b.HasIndex("UserPhoneNumber");

                    b.ToTable("entries");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsActivated");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("instructors");
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

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserPhoneNumber");

                    b.ToTable("notes");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("InstructorId");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("sexes");
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

                    b.Property<int>("InstructorId");

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

                    b.HasIndex("InstructorId");

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

                    b.Property<int>("AreaOfResidenceId");

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("EducationId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("LocalizationId");

                    b.Property<int?>("MarketStatusId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SexId");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<bool>("hasDisability");

                    b.HasKey("PhoneNumber");

                    b.HasIndex("AreaOfResidenceId");

                    b.HasIndex("EducationId");

                    b.HasIndex("LocalizationId");

                    b.HasIndex("MarketStatusId");

                    b.HasIndex("SexId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.UserLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserPhoneNumber");

                    b.ToTable("UserLog");
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

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Note", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserPhoneNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Reminder", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Instructor", "Instructor")
                        .WithMany("Reminders")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.Training", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Instructor", "Instructor")
                        .WithMany("Trainings")
                        .HasForeignKey("InstructorId")
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

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.User", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.AreaOfResidence", "areaOfResidence")
                        .WithMany()
                        .HasForeignKey("AreaOfResidenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Education", "Education")
                        .WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Localization", "Localization")
                        .WithMany()
                        .HasForeignKey("LocalizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.MarketStatus", "MarketStatus")
                        .WithMany()
                        .HasForeignKey("MarketStatusId");

                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Szkolimy_za_darmo_api.Core.Models.UserLog", b =>
                {
                    b.HasOne("Szkolimy_za_darmo_api.Core.Models.User", "User")
                        .WithMany("UserLogs")
                        .HasForeignKey("UserPhoneNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
