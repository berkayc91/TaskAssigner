﻿// <auto-generated />
using System;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(TaskAssignerContext))]
    [Migration("20240409191640_migration_1")]
    partial class migration_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<byte>("ActiveTaskId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalScore")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            ActiveTaskId = (byte)1,
                            Name = "Ahmet",
                            Surname = "Kılıç",
                            TotalScore = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            ActiveTaskId = (byte)2,
                            Name = "Ayşe",
                            Surname = "Yılmaz",
                            TotalScore = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            ActiveTaskId = (byte)3,
                            Name = "Mehmet",
                            Surname = "Kaya",
                            TotalScore = 3
                        },
                        new
                        {
                            EmployeeId = 4,
                            ActiveTaskId = (byte)4,
                            Name = "Fatma",
                            Surname = "Aslan",
                            TotalScore = 4
                        },
                        new
                        {
                            EmployeeId = 5,
                            ActiveTaskId = (byte)5,
                            Name = "Ali",
                            Surname = "Şahin",
                            TotalScore = 5
                        },
                        new
                        {
                            EmployeeId = 6,
                            ActiveTaskId = (byte)6,
                            Name = "Merve",
                            Surname = "Ak",
                            TotalScore = 6
                        });
                });

            modelBuilder.Entity("Entity.Entities.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<byte>("Difficulty")
                        .HasColumnType("tinyint");

                    b.Property<string>("DifficultyColorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            Difficulty = (byte)1,
                            DifficultyColorCode = "#00FF00",
                            Name = "Easy Task"
                        },
                        new
                        {
                            TaskId = 2,
                            Difficulty = (byte)2,
                            DifficultyColorCode = "#33FF00",
                            Name = "Simple Task"
                        },
                        new
                        {
                            TaskId = 3,
                            Difficulty = (byte)3,
                            DifficultyColorCode = "#66FF00",
                            Name = "Basic Task"
                        },
                        new
                        {
                            TaskId = 4,
                            Difficulty = (byte)4,
                            DifficultyColorCode = "#99FF00",
                            Name = "Intermediate Task"
                        },
                        new
                        {
                            TaskId = 5,
                            Difficulty = (byte)5,
                            DifficultyColorCode = "#CCFF00",
                            Name = "Advanced Task"
                        },
                        new
                        {
                            TaskId = 6,
                            Difficulty = (byte)6,
                            DifficultyColorCode = "#FF0000",
                            Name = "Difficult Task"
                        });
                });

            modelBuilder.Entity("Entity.Entities.TaskHistory", b =>
                {
                    b.Property<int>("TaskHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskHistoryId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("TaskHistoryId");

                    b.ToTable("TaskHistories");

                    b.HasData(
                        new
                        {
                            TaskHistoryId = 1,
                            EmployeeId = 1,
                            TaskDate = new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9756),
                            TaskId = 1
                        },
                        new
                        {
                            TaskHistoryId = 2,
                            EmployeeId = 2,
                            TaskDate = new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9773),
                            TaskId = 2
                        },
                        new
                        {
                            TaskHistoryId = 3,
                            EmployeeId = 3,
                            TaskDate = new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9774),
                            TaskId = 3
                        },
                        new
                        {
                            TaskHistoryId = 4,
                            EmployeeId = 4,
                            TaskDate = new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9775),
                            TaskId = 4
                        },
                        new
                        {
                            TaskHistoryId = 5,
                            EmployeeId = 5,
                            TaskDate = new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9777),
                            TaskId = 5
                        },
                        new
                        {
                            TaskHistoryId = 6,
                            EmployeeId = 6,
                            TaskDate = new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9778),
                            TaskId = 6
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
