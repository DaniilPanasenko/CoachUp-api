using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class CoachRepository : Repository<Coach>, IRepository<Coach>
    {
        public CoachRepository(CoachUpContext context) : base(context)
        {
        }

        public void Delete(string login)
        {
            Coach coach = db.Coaches.Find(login);
            if (coach != null)
                db.Coaches.Remove(coach);
        }

        public Coach Get(string login)
        {
            return db.Coaches.Find(login);
        }
    }
}