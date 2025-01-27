﻿// <auto-generated />
using System;
using CoachUp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoachUp.DAL.Migrations
{
    [DbContext(typeof(CoachUpContext))]
    partial class CoachUpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CoachUp.DAL.Entities.Box", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Num_in_Training")
                        .HasColumnType("int");

                    b.Property<int>("Training_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Training_ID");

                    b.ToTable("Boxes");
                });

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

            modelBuilder.Entity("CoachUp.DAL.Entities.CourseComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Reply_Comment_ID")
                        .HasColumnType("int");

                    b.Property<string>("User_Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.HasIndex("Course_Id");

                    b.HasIndex("Reply_Comment_ID");

                    b.HasIndex("User_Login");

                    b.ToTable("CourseComments");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Friend", b =>
                {
                    b.Property<string>("TraineeOne_Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TraineeTwo_Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.HasKey("TraineeOne_Login", "TraineeTwo_Login");

                    b.HasIndex("TraineeTwo_Login");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Media", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Box_ID")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.HasIndex("Box_ID");

                    b.ToTable("Medias");
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

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Motion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Box_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Box_ID");

                    b.ToTable("Motions");
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

                    b.Property<string>("Message")
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

            modelBuilder.Entity("CoachUp.DAL.Entities.ProffesionalMotion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("File")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Motion_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Motion_ID");

                    b.ToTable("ProffesionalMotions");
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

            modelBuilder.Entity("CoachUp.DAL.Entities.TraineeMotion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Member_ID")
                        .HasColumnType("int");

                    b.Property<int>("Motion_ID")
                        .HasColumnType("int");

                    b.Property<int>("Persent")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Member_ID");

                    b.HasIndex("Motion_ID");

                    b.ToTable("TraineeMotions");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Training", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Num_in_Course")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Course_ID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.TrainingComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Reply_Comment_ID")
                        .HasColumnType("int");

                    b.Property<int>("Training_Id")
                        .HasColumnType("int");

                    b.Property<string>("User_Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.HasIndex("Reply_Comment_ID");

                    b.HasIndex("Training_Id");

                    b.HasIndex("User_Login");

                    b.ToTable("TrainingComments");
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

            modelBuilder.Entity("CoachUp.DAL.Entities.Box", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Training", "Training")
                        .WithMany("Boxes")
                        .HasForeignKey("Training_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
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

            modelBuilder.Entity("CoachUp.DAL.Entities.CourseComment", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachUp.DAL.Entities.CourseComment", "Reply_Comment")
                        .WithMany("Reply_Comments")
                        .HasForeignKey("Reply_Comment_ID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("CoachUp.DAL.Entities.User", "User")
                        .WithMany("CourseComments")
                        .HasForeignKey("User_Login")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Reply_Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Friend", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Trainee", "Trainee1")
                        .WithMany("FriendsSend")
                        .HasForeignKey("TraineeOne_Login")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CoachUp.DAL.Entities.Trainee", "Trainee2")
                        .WithMany("FriendsRequest")
                        .HasForeignKey("TraineeTwo_Login")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Trainee1");

                    b.Navigation("Trainee2");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Media", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Box", "Box")
                        .WithMany("Medias")
                        .HasForeignKey("Box_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Box");
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
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Motion", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Box", "Box")
                        .WithMany("Motions")
                        .HasForeignKey("Box_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Box");
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

            modelBuilder.Entity("CoachUp.DAL.Entities.ProffesionalMotion", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Motion", "Motion")
                        .WithMany("ProffesionalMotions")
                        .HasForeignKey("Motion_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motion");
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

            modelBuilder.Entity("CoachUp.DAL.Entities.TraineeMotion", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Member", "Member")
                        .WithMany("TraineeMotions")
                        .HasForeignKey("Member_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CoachUp.DAL.Entities.Motion", "Motion")
                        .WithMany("TraineeMotions")
                        .HasForeignKey("Motion_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Motion");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Training", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.Course", "Course")
                        .WithMany("Trainings")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.TrainingComment", b =>
                {
                    b.HasOne("CoachUp.DAL.Entities.TrainingComment", "Reply_Comment")
                        .WithMany("Reply_Comments")
                        .HasForeignKey("Reply_Comment_ID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("CoachUp.DAL.Entities.Training", "Training")
                        .WithMany()
                        .HasForeignKey("Training_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachUp.DAL.Entities.User", "User")
                        .WithMany("TrainingComments")
                        .HasForeignKey("User_Login")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Reply_Comment");

                    b.Navigation("Training");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Box", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("Motions");
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

                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.CourseComment", b =>
                {
                    b.Navigation("Reply_Comments");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Member", b =>
                {
                    b.Navigation("TraineeMotions");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Motion", b =>
                {
                    b.Navigation("ProffesionalMotions");

                    b.Navigation("TraineeMotions");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Trainee", b =>
                {
                    b.Navigation("FriendsRequest");

                    b.Navigation("FriendsSend");

                    b.Navigation("Member_in_Courses");

                    b.Navigation("Subscribes");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.Training", b =>
                {
                    b.Navigation("Boxes");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.TrainingComment", b =>
                {
                    b.Navigation("Reply_Comments");
                });

            modelBuilder.Entity("CoachUp.DAL.Entities.User", b =>
                {
                    b.Navigation("CourseComments");

                    b.Navigation("Notifications");

                    b.Navigation("TrainingComments");
                });
#pragma warning restore 612, 618
        }
    }
}
