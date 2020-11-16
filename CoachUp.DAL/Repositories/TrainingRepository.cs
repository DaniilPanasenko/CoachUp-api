using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class TrainingRepository : Repository<Training>, IRepository<Training>
    {
        public TrainingRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
