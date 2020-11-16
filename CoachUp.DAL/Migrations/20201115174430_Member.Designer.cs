﻿// <auto-generated />
using System;
using CoachUp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoachUp.DAL.Migrations
{
    [DbContext(typeof(CoachUpContext))]
    [Migration("20201115174430_Member")]
    partial class Member
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CoachUp.DAL.Entities.Career", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Coach_Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Company")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("FYear")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SYear")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Coach_Login");

                    b.ToTable("Careers");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Coach", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Avatar_Link")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Sport_ID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Login");

                    b.HasIndex("Sport_ID");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Coach_Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("Coach_Login");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Trainee_Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.HasIndex("Course_Id");

                    b.HasIndex("Trainee_Login");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Messge")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("User_Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.HasIndex("User_Login");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Sport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Subscribe", b =>
                {
                    b.Property<string>("Coach_Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Trainee_Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Coach_Login", "Trainee_Login");

                    b.HasIndex("Trainee_Login");

                    b.ToTable("Subscribes");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Trainee", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Avatar_Link")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Login");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.User", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Login");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Career", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Coach", "Coach")
                        .WithMany("Careers")
                        .HasForeignKey("Coach_Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Coach", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachUp.DAL.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("Sport_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Course", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Coach", "Coach")
                        .WithMany("Courses")
                        .HasForeignKey("Coach_Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Member", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Course", "Course")
                        .WithMany("Members")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachUp.DAL.Entities.Trainee", "Trainee")
                        .WithMany("Member_in_Courses")
                        .HasForeignKey("Trainee_Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Notification", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("User_Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Subscribe", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Coach", "Coach")
                        .WithMany("Subscribes")
                        .HasForeignKey("Coach_Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachUp.DAL.Entities.Trainee", "Trainee")
                        .WithMany("Subscribes")
                        .HasForeignKey("Trainee_Login")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Trainee", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Coach", b =>
                {
                    b.Navigation("Careers");

                    b.Navigation("Courses");

                    b.Navigation("Subscribes");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Course", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Trainee", b =>
                {
                    b.Navigation("Member_in_Courses");

                    b.Navigation("Subscribes");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.User", b =>
                {
                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}