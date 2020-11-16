using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class BoxRepository : Repository<Box>, IRepository<Box>
    {
        public BoxRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
