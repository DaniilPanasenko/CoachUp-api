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
        private CoachUpContext db { get; set; }
        public UnitOfWork()
        {
            db = new CoachUpContext();
        }

        private UserRepository userRepository;

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        private SportRepository sportRepository;

        public SportRepository Sports
        {
            get
            {
                if (sportRepository == null)
                    sportRepository = new SportRepository(db);
                return sportRepository;
            }
        }

        private CoachRepository coachRepository;

        public CoachRepository Coaches
        {
            get
            {
                if (coachRepository == null)
                    coachRepository = new CoachRepository(db);
                return coachRepository;
            }
        }
        private TraineeRepository traineeRepository;

        public TraineeRepository Trainees
        {
            get
            {
                if (traineeRepository == null)
                    traineeRepository = new TraineeRepository(db);
                return traineeRepository;
            }
        }

        private NotificationRepository notificationRepository;

        public NotificationRepository Notifications
        {
            get
            {
                if (notificationRepository == null)
                    notificationRepository = new NotificationRepository(db);
                return notificationRepository;
            }
        }

        private SubscribeRepository subscribeRepository;

        public SubscribeRepository Subscribes
        {
            get
            {
                if (subscribeRepository == null)
                    subscribeRepository = new SubscribeRepository(db);
                return subscribeRepository;
            }
        }

        private CareerRepository careerRepository;

        public CareerRepository Careers
        {
            get
            {
                if (careerRepository == null)
                    careerRepository = new CareerRepository(db);
                return careerRepository;
            }
        }

        private CourseRepository courseRepository;

        public CourseRepository Courses
        {
            get
            {
                if (courseRepository == null)
                    courseRepository = new CourseRepository(db);
                return courseRepository;
            }
        }

        private MemberRepository memberRepository;

        public MemberRepository Members
        {
            get
            {
                if (memberRepository == null)
                    memberRepository = new MemberRepository(db);
                return memberRepository;
            }
        }

        private TrainingRepository trainingRepository;

        public TrainingRepository Trainings
        {
            get
            {
                if (trainingRepository == null)
                    trainingRepository = new TrainingRepository(db);
                return trainingRepository;
            }
        }

        private BoxRepository boxRepository;

        public BoxRepository Boxes
        {
            get
            {
                if (boxRepository == null)
                    boxRepository = new BoxRepository(db);
                return boxRepository;
            }
        }

        private MotionRepository motionRepository;

        public MotionRepository Motions
        {
            get
            {
                if (motionRepository == null)
                    motionRepository = new MotionRepository(db);
                return motionRepository;
            }
        }

        private MediaRepository mediaRepository;

        public MediaRepository Medias
        {
            get
            {
                if (mediaRepository == null)
                    mediaRepository = new MediaRepository(db);
                return mediaRepository;
            }
        }

        private TraineeMotionRepository traineeMotionRepository;

        public TraineeMotionRepository TraineeMotions
        {
            get
            {
                if (traineeMotionRepository == null)
                    traineeMotionRepository = new TraineeMotionRepository(db);
                return traineeMotionRepository;
            }
        }

        private ProffesionalMotionRepository proffesionalMotionRepository;

        public ProffesionalMotionRepository ProffesionalMotions
        {
            get
            {
                if (proffesionalMotionRepository == null)
                    proffesionalMotionRepository = new ProffesionalMotionRepository(db);
                return proffesionalMotionRepository;
            }
        }

        private FriendRepository friendRepository;

        public FriendRepository Friends
        {
            get
            {
                if (friendRepository == null)
                    friendRepository = new FriendRepository(db);
                return friendRepository;
            }
        }

        private CourseCommentRepository courseCommentRepository;

        public CourseCommentRepository CourseComments
        {
            get
            {
                if (courseCommentRepository == null)
                    courseCommentRepository = new CourseCommentRepository(db);
                return courseCommentRepository;
            }
        }

        private TrainingCommentRepository trainingCommentRepository;

        public TrainingCommentRepository TrainingComments
        {
            get
            {
                if (trainingCommentRepository == null)
                    trainingCommentRepository = new TrainingCommentRepository(db);
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
