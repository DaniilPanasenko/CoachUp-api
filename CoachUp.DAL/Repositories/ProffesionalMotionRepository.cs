using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class ProffesionalMotionRepository : Repository<ProffesionalMotion>, IRepository<ProffesionalMotion>
    {
        public ProffesionalMotionRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
