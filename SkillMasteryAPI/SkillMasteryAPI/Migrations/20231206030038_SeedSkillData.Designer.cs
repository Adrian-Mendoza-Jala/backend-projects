﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillMasteryAPI.Data;

#nullable disable

namespace SkillMasteryAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231206030038_SeedSkillData")]
    partial class SeedSkillData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkillMasteryAPI.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The ability to write computer programs",
                            Name = "Programming"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The ability to create designs for user interfaces",
                            Name = "Design"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The ability to manage and maintain database management systems",
                            Name = "Database"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
