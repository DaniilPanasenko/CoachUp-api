using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class CareerRepository : Repository<Career>, IRepository<Career>
    {
        public CareerRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
