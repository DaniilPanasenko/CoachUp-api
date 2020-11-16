using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class MemberRepository : Repository<Member>, IRepository<Member>
    {
        public MemberRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
