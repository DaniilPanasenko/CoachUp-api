using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class FriendRepository : Repository<Friend>, IRepository<Friend>
    {
        public FriendRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
