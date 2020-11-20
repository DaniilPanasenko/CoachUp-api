using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class NotificationsService
    {
        private UnitOfWork db;
        public NotificationsService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public int GetCountUnreadedMessages(string login)
        {
            User user = db.Users.Get(login);
            return user.Notifications
                .Where(x => !x.IsRead)
                .Count();
        }

        public void AddNotification(string message, string login)
        {
            User user = db.Users.Get(login);
            Notification notification = new Notification()
            {
                Message = message,
                IsRead = false,
                DateTime = DateTime.Now,
                User = user
            };
            db.Notifications.Create(notification);
            db.Save();
        }

    }
}