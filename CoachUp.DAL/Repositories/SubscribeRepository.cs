using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class SubscribeRepository : Repository<Subscribe>, IRepository<Subscribe>
    {
        public SubscribeRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
