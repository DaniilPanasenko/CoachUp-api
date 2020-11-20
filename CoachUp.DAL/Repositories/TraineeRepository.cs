using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoachUp.DAL.Repositories
{
    public class TraineeRepository : Repository<Trainee>, IRepository<Trainee>
    {
        public TraineeRepository(CoachUpContext context) : base(context)
        {
        }

        public void Delete(string login)
        {
            Trainee trainee = db.Trainees.Find(login);
            if (trainee != null)
                db.Trainees.Remove(trainee);
        }

        public Trainee Get(string login)
        {
            return db.Trainees.Find(login);
        }
    }
}