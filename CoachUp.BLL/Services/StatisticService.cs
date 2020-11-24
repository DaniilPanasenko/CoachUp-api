using CoachUp.BLL.BusinessModels;
using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class StatisticService
    {
        private UnitOfWork db;
        public StatisticService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public MotionComplete GetMotionStatisticByUser(string login, int box_ID)
        {
            int motion_ID = db.Motions.Find(x => x.Box_ID == box_ID).First().ID;

            int[] marks = db.Motions
                .Get(motion_ID)
                .TraineeMotions
                .Where(x => x.Member.Trainee_Login == login)
                .OrderByDescending(x => x.DateTime)
                .Select(x => x.Persent)
                .ToArray();

            MotionComplete motionComplete = new MotionComplete(marks, login);

            Trainee trainee = db.Trainees
                .Get(login);
            string[] friends_login = trainee.FriendsRequest
                .Where(x => x.Accepted)
                .Where(x => x.Trainee1.Member_in_Courses
                    .Any(y => y.TraineeMotions
                    .Any(y => y.Motion.Box_ID == box_ID)))
                .Select(x => x.TraineeOne_Login)
                .Concat(db.Trainees
                    .Get(login).FriendsSend
                    .Where(x => x.Accepted)
                    .Where(x => x.Trainee2.Member_in_Courses
                        .Any(y => y.TraineeMotions
                        .Any(y => y.Motion.Box_ID == box_ID)))
                    .Select(x => x.TraineeTwo_Login))
                .ToArray();

            int[][] friends_marks = friends_login
                .Select(x=> db.Motions
                    .Get(motion_ID)
                    .TraineeMotions
                    .Where(y => y.Member.Trainee_Login == x)
                    .OrderByDescending(y => y.DateTime)
                    .Select(y => y.Persent)
                    .ToArray())
              .ToArray();

            motionComplete. SetFriendsRate(friends_marks, friends_login);

            return motionComplete;
        }

    }
}