using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class MotionService
    {
        private UnitOfWork db;
        public MotionService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public List<string> GetProfessionalMotion(int id)
        {
            return db.ProffesionalMotions
                .Find(x => x.Motion_ID == id)
                .Select(x => x.File)
                .ToList();
        }

        public void AddProfessionalMotion(int id, string file)
        {
            ProffesionalMotion motion = new ProffesionalMotion
            {
                Motion_ID = id,
                File = file
            };
            db.ProffesionalMotions.Create(motion);
            db.Save();
        }

        public void AddTraineeMotion(int id, string login, string file, int persent)
        {
            int box_id = db.Motions.Get(id).Box_ID;
            TraineeMotion motion = new TraineeMotion
            {
                Motion_ID = id,
                File = file,
                DateTime = DateTime.Now,
                Persent = persent,
                Member_ID = db.Members
                .Find(x =>
                    x.Trainee_Login == login &&
                    x.Course.Trainings
                    .Any(y => y.Boxes
                        .Any(z => z.ID == box_id)))
                .First().ID
            };
            db.TraineeMotions.Create(motion);
            db.Save();
        }

    }
}