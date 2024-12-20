﻿// <auto-generated />
using System;
using ClassRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassRoom.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241121091523_updateSubmission")]
    partial class updateSubmission
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassRoom.Models.AppFiles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("id");

                    b.ToTable("files", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Assignment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("classRoomId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("classRoomId");

                    b.ToTable("Assignment", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Class", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("instructorId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("code")
                        .IsUnique();

                    b.HasIndex("instructorId");

                    b.ToTable("classRooms", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.ClassRoomStudent", b =>
                {
                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<int>("classRoomId")
                        .HasColumnType("int");

                    b.HasKey("studentId", "classRoomId");

                    b.HasIndex("classRoomId");

                    b.ToTable("classRoomStudents", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Instructor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Instructors", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Lecture", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("classRoomId")
                        .HasColumnType("int");

                    b.Property<int>("lectureFileId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("classRoomId");

                    b.HasIndex("lectureFileId");

                    b.ToTable("lectures", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Submission", b =>
                {
                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<int>("fileId")
                        .HasColumnType("int");

                    b.Property<int>("studentScore")
                        .HasColumnType("int");

                    b.HasKey("studentId", "assignmentId");

                    b.HasIndex("assignmentId");

                    b.HasIndex("fileId")
                        .IsUnique();

                    b.ToTable("submissions", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Token", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Instructorid")
                        .HasColumnType("int");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("invoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Instructorid");

                    b.HasIndex("userId");

                    b.ToTable("tokens", (string)null);
                });

            modelBuilder.Entity("ClassRoom.Models.Assignment", b =>
                {
                    b.HasOne("ClassRoom.Models.Class", "classRoom")
                        .WithMany("assignments")
                        .HasForeignKey("classRoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("classRoom");
                });

            modelBuilder.Entity("ClassRoom.Models.Class", b =>
                {
                    b.HasOne("ClassRoom.Models.Instructor", "instructor")
                        .WithMany("classRooms")
                        .HasForeignKey("instructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("ClassRoom.Models.ClassRoomStudent", b =>
                {
                    b.HasOne("ClassRoom.Models.Class", "classRoom")
                        .WithMany("ClassRoomStudents")
                        .HasForeignKey("classRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassRoom.Models.Student", "student")
                        .WithMany("ClassRoomStudents")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("classRoom");

                    b.Navigation("student");
                });

            modelBuilder.Entity("ClassRoom.Models.Lecture", b =>
                {
                    b.HasOne("ClassRoom.Models.Class", "classRoom")
                        .WithMany("lectures")
                        .HasForeignKey("classRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassRoom.Models.AppFiles", "lectureFile")
                        .WithMany()
                        .HasForeignKey("lectureFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("classRoom");

                    b.Navigation("lectureFile");
                });

            modelBuilder.Entity("ClassRoom.Models.Submission", b =>
                {
                    b.HasOne("ClassRoom.Models.Assignment", "assignment")
                        .WithMany("submissions")
                        .HasForeignKey("assignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassRoom.Models.AppFiles", "file")
                        .WithOne()
                        .HasForeignKey("ClassRoom.Models.Submission", "fileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassRoom.Models.Student", "student")
                        .WithMany("studentSubmission")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignment");

                    b.Navigation("file");

                    b.Navigation("student");
                });

            modelBuilder.Entity("ClassRoom.Models.Token", b =>
                {
                    b.HasOne("ClassRoom.Models.Instructor", null)
                        .WithMany("tokens")
                        .HasForeignKey("Instructorid");

                    b.HasOne("ClassRoom.Models.Student", "user")
                        .WithMany("tokens")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ClassRoom.Models.Assignment", b =>
                {
                    b.Navigation("submissions");
                });

            modelBuilder.Entity("ClassRoom.Models.Class", b =>
                {
                    b.Navigation("ClassRoomStudents");

                    b.Navigation("assignments");

                    b.Navigation("lectures");
                });

            modelBuilder.Entity("ClassRoom.Models.Instructor", b =>
                {
                    b.Navigation("classRooms");

                    b.Navigation("tokens");
                });

            modelBuilder.Entity("ClassRoom.Models.Student", b =>
                {
                    b.Navigation("ClassRoomStudents");

                    b.Navigation("studentSubmission");

                    b.Navigation("tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
