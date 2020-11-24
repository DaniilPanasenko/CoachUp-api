using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class SubscribesService
    {
        private UnitOfWork db;
        private ServiceModule sm;
        public SubscribesService(ServiceModule _sm)
        {
            db = _sm.DB;
            sm = _sm;
        }

        public List<ShortSubscribeDTO> GetTop20Subscribes(string login)
        {

            Trainee trainee = db.Trainees.Get(login);
            if (trainee != null)
            {
                List<Coach> subscribes = trainee.Subscribes
                    .Select(x => x.Coach)
                    .ToList();

                List<ShortSubscribeDTO> result = subscribes
                    .Select(x => new ShortSubscribeDTO(x))
                    .OrderByDescending(x => x.Rate.Points)
                    .Take(20)
                    .ToList();

                return result;
            }
            return null;
        }

        public List<ShortSubscriberDTO> GetTop20Subscribers(string login)
        {

            Coach coach = db.Coaches.Get(login);
            if (coach != null)
            {
                List<Trainee> subscribes = coach.Subscribes
                    .Select(x => x.Trainee)
                    .ToList();

                List<ShortSubscriberDTO> result = subscribes
                    .Select(x => new ShortSubscriberDTO(x))
                    .OrderByDescending(x => x.Rate.Points)
                    .Take(20)
                    .ToList();

                return result;
            }
            return null;
        }

        public void AddSubscribe(string my_login, string coach_login)
        {
            Trainee me = db.Trainees.Get(my_login);
            Coach coach = db.Coaches.Get(coach_login);
            Subscribe subscribe = db.Subscribes
                .Find(x =>
                x.Coach_Login == coach_login &&
                x.Trainee_Login == my_login)
                .FirstOrDefault();
            if (me != null && coach != null && subscribe == null)
            {
                NotificationsService service = new NotificationsService(sm);
                service.AddNotification($"User {me.Login} followed you", coach_login);
                Subscribe new_subscribe = new Subscribe()
                {
                    Trainee = me,
                    Coach = coach
                };
                db.Subscribes.Create(new_subscribe);
                db.Save();
            }
        }

    }
}