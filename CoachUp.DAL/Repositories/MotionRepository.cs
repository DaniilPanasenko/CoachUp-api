using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class MotionRepository : Repository<Motion>, IRepository<Motion>
    {
        public MotionRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
