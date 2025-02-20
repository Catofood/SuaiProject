﻿// <auto-generated />
using Bot.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bot.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    partial class ScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bot.Db.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Bot.Db.Study", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Building")
                        .HasColumnType("text");

                    b.Property<int?>("Day")
                        .HasColumnType("integer");

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.Property<string>("Discipline")
                        .HasColumnType("text");

                    b.Property<string>("Room")
                        .HasColumnType("text");

                    b.Property<int?>("SchedulePosition")
                        .HasColumnType("integer");

                    b.Property<string>("Teacher")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<int?>("Week")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("Bot.Db.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupId")
                        .HasColumnType("text");

                    b.Property<int?>("GroupId1")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GroupStudy", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.Property<int>("StudiesId")
                        .HasColumnType("integer");

                    b.HasKey("GroupsId", "StudiesId");

                    b.HasIndex("StudiesId");

                    b.ToTable("GroupStudy");
                });

            modelBuilder.Entity("Bot.Db.User", b =>
                {
                    b.HasOne("Bot.Db.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId1");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GroupStudy", b =>
                {
                    b.HasOne("Bot.Db.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bot.Db.Study", null)
                        .WithMany()
                        .HasForeignKey("StudiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bot.Db.Group", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
