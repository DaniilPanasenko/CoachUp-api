using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class TraineeMotionRepository : Repository<TraineeMotion>, IRepository<TraineeMotion>
    {
        public TraineeMotionRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
