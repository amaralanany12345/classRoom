﻿// <auto-generated />
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
    [Migration("20241112095531_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("instructorId")
                        .HasColumnType("int");

                    b.HasKey("id");

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

            modelBuilder.Entity("ClassRoom.Models.Class", b =>
                {
                    b.Navigation("ClassRoomStudents");
                });

            modelBuilder.Entity("ClassRoom.Models.Instructor", b =>
                {
                    b.Navigation("classRooms");
                });

            modelBuilder.Entity("ClassRoom.Models.Student", b =>
                {
                    b.Navigation("ClassRoomStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
