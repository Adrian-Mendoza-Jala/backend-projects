﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SkillMasteryAPI.Infrastructure.Data;

#nullable disable

namespace SkillMasteryAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SkillMasteryAPI.Domain.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3822),
                            Deadline = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Complete a basic programming course",
                            SkillId = 1,
                            Status = 1,
                            UpdatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3822)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3830),
                            Deadline = new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Design a user interface for a mobile app",
                            SkillId = 2,
                            Status = 0,
                            UpdatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3830)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3832),
                            Deadline = new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Optimize database performance",
                            SkillId = 3,
                            Status = 1,
                            UpdatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3832)
                        });
                });

            modelBuilder.Entity("SkillMasteryAPI.Domain.Entities.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Milestones")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Progresses", (string)null);
                });

            modelBuilder.Entity("SkillMasteryAPI.Domain.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Skills", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3574),
                            Description = "The ability to write computer programs",
                            Name = "Programming",
                            UpdatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3576)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3578),
                            Description = "The ability to create designs for user interfaces",
                            Name = "Design",
                            UpdatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3578)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3579),
                            Description = "The ability to manage and maintain database management systems",
                            Name = "Database",
                            UpdatedAt = new DateTime(2024, 2, 28, 20, 13, 7, 975, DateTimeKind.Utc).AddTicks(3580)
                        });
                });

            modelBuilder.Entity("SkillMasteryAPI.Domain.Entities.Goal", b =>
                {
                    b.HasOne("SkillMasteryAPI.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("SkillMasteryAPI.Domain.Entities.Progress", b =>
                {
                    b.HasOne("SkillMasteryAPI.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });
#pragma warning restore 612, 618
        }
    }
}
