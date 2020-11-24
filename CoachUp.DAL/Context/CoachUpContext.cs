using System;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.SqlServer;

using CoachUp.DAL.Entities;

namespace CoachUp.DAL.Context
{
    public class CoachUpContext : DbContext
    {

        private static string connectionString =
            "Server=tcp:coachup.database.windows.net,1433;" +
            "Initial Catalog=CoachUp;" +
            "Persist Security Info=False;" +
            "User ID=daniil;" +
            "Password=coachup_01;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;" +
            "Connection Timeout=30;" +
            "MultipleActiveResultSets=true;";
        private static DbContextOptions opt =
            SqlServerDbContextOptionsExtensions.UseSqlServer(
                new DbContextOptionsBuilder(),
                connectionString).Options;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public CoachUpContext() : base(opt)
        {
            
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Trainee> Trainees { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Subscribe> Subscribes { get; set; }

        public DbSet<Career> Careers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<Motion> Motions { get; set; }

        public DbSet<Media> Medias { get; set; }

        public DbSet<TraineeMotion> TraineeMotions { get; set; }

        public DbSet<ProffesionalMotion> ProffesionalMotions { get; set; }

        public DbSet<Friend> Friends { get; set; }

        public DbSet<TrainingComment> TrainingComments { get; set; }

        public DbSet<CourseComment> CourseComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subscribe>().
                HasKey(x => new { x.Coach_Login, x.Trainee_Login });

            modelBuilder.Entity<Friend>().
                HasKey(x => new { x.TraineeOne_Login, x.TraineeTwo_Login });

            modelBuilder.Entity<Trainee>()
            .HasMany(p => p.Member_in_Courses)
            .WithOne(p => p.Trainee)
            .IsRequired()
            .HasForeignKey(s => s.Trainee_Login);

            modelBuilder.Entity<Coach>()
            .HasMany(p => p.Subscribes)
            .WithOne(p => p.Coach)
            .IsRequired()
            .HasForeignKey(s => s.Coach_Login);

            modelBuilder.Entity<Trainee>()
            .HasMany(p => p.Subscribes)
            .WithOne(p => p.Trainee)
            .IsRequired()
            .HasForeignKey(s => s.Trainee_Login)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Trainee>()
            .HasMany(p => p.Member_in_Courses)
            .WithOne(p => p.Trainee)
            .IsRequired()
            .HasForeignKey(s => s.Trainee_Login)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Member>()
            .HasMany(p => p.TraineeMotions)
            .WithOne(p => p.Member)
            .IsRequired()
            .HasForeignKey(s => s.Member_ID)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Friend>()
            .HasOne(p=>p.Trainee1)
            .WithMany(t=>t.FriendsSend)
            .HasForeignKey(t=>t.TraineeOne_Login)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Friend>()
            .HasOne(p => p.Trainee2)
            .WithMany(t => t.FriendsRequest)
            .HasForeignKey(t => t.TraineeTwo_Login)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
            .HasMany(p => p.CourseComments)
            .WithOne(p => p.User)
            .IsRequired()
            .HasForeignKey(s => s.User_Login)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
            .HasMany(p => p.TrainingComments)
            .WithOne(p => p.User)
            .IsRequired()
            .HasForeignKey(s => s.User_Login)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrainingComment>()
            .HasMany(p => p.Reply_Comments)
            .WithOne(p => p.Reply_Comment)
            .IsRequired(false)
            .HasForeignKey(s => s.Reply_Comment_ID)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CourseComment>()
            .HasMany(p => p.Reply_Comments)
            .WithOne(p => p.Reply_Comment)
            .IsRequired(false)
            .HasForeignKey(s => s.Reply_Comment_ID)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
