﻿// <auto-generated />
using Bot.DB;
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

            modelBuilder.Entity("Bot.DB.DailySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<int>("WeeklyScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WeeklyScheduleId");

                    b.ToTable("DailySchedules");
                });

            modelBuilder.Entity("Bot.DB.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Bot.DB.ScheduledStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DailyScheduleId")
                        .HasColumnType("integer");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SchedulePosition")
                        .HasColumnType("integer");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DailyScheduleId");

                    b.ToTable("ScheduledStudies");
                });

            modelBuilder.Entity("Bot.DB.UnscheduledStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("UnscheduledStudies");
                });

            modelBuilder.Entity("Bot.DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<int>("TelegramId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bot.DB.WeeklySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("Week")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("WeeklySchedules");
                });

            modelBuilder.Entity("Bot.DB.DailySchedule", b =>
                {
                    b.HasOne("Bot.DB.WeeklySchedule", "WeeklySchedule")
                        .WithMany("DailySchedules")
                        .HasForeignKey("WeeklyScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeeklySchedule");
                });

            modelBuilder.Entity("Bot.DB.ScheduledStudy", b =>
                {
                    b.HasOne("Bot.DB.DailySchedule", "DailySchedule")
                        .WithMany("ScheduledStudies")
                        .HasForeignKey("DailyScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DailySchedule");
                });

            modelBuilder.Entity("Bot.DB.UnscheduledStudy", b =>
                {
                    b.HasOne("Bot.DB.Group", "Group")
                        .WithMany("UnscheduledStudies")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Bot.DB.User", b =>
                {
                    b.HasOne("Bot.DB.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Bot.DB.WeeklySchedule", b =>
                {
                    b.HasOne("Bot.DB.Group", "Group")
                        .WithMany("WeeklySchedules")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Bot.DB.DailySchedule", b =>
                {
                    b.Navigation("ScheduledStudies");
                });

            modelBuilder.Entity("Bot.DB.Group", b =>
                {
                    b.Navigation("UnscheduledStudies");

                    b.Navigation("Users");

                    b.Navigation("WeeklySchedules");
                });

            modelBuilder.Entity("Bot.DB.WeeklySchedule", b =>
                {
                    b.Navigation("DailySchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
