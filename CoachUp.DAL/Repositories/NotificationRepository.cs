using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class NotificationRepository : Repository<Notification>, IRepository<Notification>
    {
        public NotificationRepository(CoachUpContext context) : base(context)
        {
        }

    }
}