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
        public SubscribesService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public List<ShortSubscribeDTO> GetTop20Subscribes(string login)
        {

            Trainee trainee = db.Trainees.Get(login);

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

    }
}