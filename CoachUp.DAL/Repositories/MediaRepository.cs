using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class MediaRepository : Repository<Media>, IRepository<Media>
    {
        public MediaRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
