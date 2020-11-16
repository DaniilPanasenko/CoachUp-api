using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class TrainingCommentRepository : Repository<Training>, IRepository<Training>
    {
        public TrainingCommentRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
