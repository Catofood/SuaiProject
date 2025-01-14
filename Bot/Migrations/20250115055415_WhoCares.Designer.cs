﻿// <auto-generated />
using System.Collections.Generic;
using Bot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bot.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    [Migration("20250115055415_WhoCares")]
    partial class WhoCares
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClassLibrary.ScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Classroom")
                        .HasColumnType("text");

                    b.Property<int?>("DayOfWeekNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.PrimitiveCollection<List<string>>("GroupNames")
                        .HasColumnType("text[]");

                    b.Property<bool?>("IsWeekOdd")
                        .HasColumnType("boolean");

                    b.Property<string>("LessonName")
                        .HasColumnType("text");

                    b.Property<int?>("LessonNumber")
                        .HasColumnType("integer");

                    b.Property<string>("LocationName")
                        .HasColumnType("text");

                    b.Property<string>("Teacher")
                        .HasColumnType("text");

                    b.Property<string>("TypeOfLesson")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });
#pragma warning restore 612, 618
        }
    }
}
