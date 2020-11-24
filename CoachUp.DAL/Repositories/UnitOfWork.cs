using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CoachUp.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public CoachUpContext db { get; set; }
        public UnitOfWork()
        {
            db = new CoachUpContext();
        }

        private Repository<User> userRepository;

        public Repository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<User>(db);
                return userRepository;
            }
        }

        private Repository<Sport> sportRepository;

        public Repository<Sport> Sports
        {
            get
            {
                if (sportRepository == null)
                    sportRepository = new Repository<Sport>(db);
                return sportRepository;
            }
        }

        private Repository<Coach> coachRepository;

        public Repository<Coach> Coaches
        {
            get
            {
                if (coachRepository == null)
                    coachRepository = new Repository<Coach>(db);
                return coachRepository;
            }
        }

        private Repository<Trainee> traineeRepository;

        public Repository<Trainee> Trainees
        {
            get
            {
                if (traineeRepository == null)
                    traineeRepository = new Repository<Trainee>(db);
                return traineeRepository;
            }
        }

        private Repository<Notification> notificationRepository;

        public Repository<Notification> Notifications
        {
            get
            {
                if (notificationRepository == null)
                    notificationRepository = new Repository<Notification>(db);
                return notificationRepository;
            }
        }

        private Repository<Subscribe> subscribeRepository;

        public Repository<Subscribe> Subscribes
        {
            get
            {
                if (subscribeRepository == null)
                    subscribeRepository = new Repository<Subscribe>(db);
                return subscribeRepository;
            }
        }

        private Repository<Career> careerRepository;

        public Repository<Career> Careers
        {
            get
            {
                if (careerRepository == null)
                    careerRepository = new Repository<Career>(db);
                return careerRepository;
            }
        }

        private Repository<Course> courseRepository;

        public Repository<Course> Courses
        {
            get
            {
                if (courseRepository == null)
                    courseRepository = new Repository<Course>(db);
                return courseRepository;
            }
        }

        private Repository<Member> memberRepository;

        public Repository<Member> Members
        {
            get
            {
                if (memberRepository == null)
                    memberRepository = new Repository<Member>(db);
                return memberRepository;
            }
        }

        private Repository<Training> trainingRepository;

        public Repository<Training> Trainings
        {
            get
            {
                if (trainingRepository == null)
                    trainingRepository = new Repository<Training>(db);
                return trainingRepository;
            }
        }

        private Repository<Box> boxRepository;

        public Repository<Box> Boxes
        {
            get
            {
                if (boxRepository == null)
                    boxRepository = new Repository<Box>(db);
                return boxRepository;
            }
        }

        private Repository<Motion> motionRepository;

        public Repository<Motion> Motions
        {
            get
            {
                if (motionRepository == null)
                    motionRepository = new Repository<Motion>(db);
                return motionRepository;
            }
        }

        private Repository<Media> mediaRepository;

        public Repository<Media> Medias
        {
            get
            {
                if (mediaRepository == null)
                    mediaRepository = new Repository<Media>(db);
                return mediaRepository;
            }
        }

        private Repository<TraineeMotion> traineeMotionRepository;

        public Repository<TraineeMotion> TraineeMotions
        {
            get
            {
                if (traineeMotionRepository == null)
                    traineeMotionRepository = new Repository<TraineeMotion>(db);
                return traineeMotionRepository;
            }
        }

        private Repository<ProffesionalMotion> proffesionalMotionRepository;

        public Repository<ProffesionalMotion> ProffesionalMotions
        {
            get
            {
                if (proffesionalMotionRepository == null)
                    proffesionalMotionRepository = new Repository<ProffesionalMotion>(db);
                return proffesionalMotionRepository;
            }
        }

        private Repository<Friend> friendRepository;

        public Repository<Friend> Friends
        {
            get
            {
                if (friendRepository == null)
                    friendRepository = new Repository<Friend>(db);
                return friendRepository;
            }
        }

        private Repository<CourseComment> courseCommentRepository;

        public Repository<CourseComment> CourseComments
        {
            get
            {
                if (courseCommentRepository == null)
                    courseCommentRepository = new Repository<CourseComment>(db);
                return courseCommentRepository;
            }
        }

        private Repository<TrainingComment> trainingCommentRepository;

        public Repository<TrainingComment> TrainingComments
        {
            get
            {
                if (trainingCommentRepository == null)
                    trainingCommentRepository = new Repository<TrainingComment>(db);
                return trainingCommentRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
