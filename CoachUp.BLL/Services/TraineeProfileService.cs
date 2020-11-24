using CoachUp.BLL.BusinessModels;
using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class TraineeProfileService
    {
        private UnitOfWork db;
        public TraineeProfileService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public TraineeProfileDTO GetInfo(string login)
        {
            Trainee trainee = db.Trainees.Get(login);
            if (trainee != null)
            {
                TraineeProfileDTO profile = new TraineeProfileDTO(trainee);

                profile.Count_Friends = trainee.FriendsSend
                    .Where(x => x.Accepted)
                    .Count() +
                    trainee.FriendsRequest
                        .Where(x => x.Accepted)
                        .Count();

                profile.Sports = trainee.Member_in_Courses
                    .Select(x => x.Course.Coach.Sport.Name)
                    .Distinct()
                    .ToList();

                profile.Count_Subscribes = trainee.Subscribes.Count();

                List<TraineeRate> trainees = db.Trainees
                    .GetAll()
                    .Select(x=>new TraineeRate(x))
                    .OrderByDescending(x=>x.Points)
                    .ToList();
                int place = 1;
                foreach(TraineeRate rate in trainees)
                {
                    if(profile.Rate.Points < rate.Points)
                    {
                        place++;
                    }
                    else
                    {
                        break;
                    }
                }
                profile.Rate.Place = place;

                return profile;
            }
            return null;
        }

        public void EditProfile(TraineeDTO traineeDTO)
        {
            Trainee trainee = new Trainee
            {
                Login = traineeDTO.Login,
                Avatar_Link = traineeDTO.Avatar_Link,
                Name = traineeDTO.Name,
                Surname = traineeDTO.Surname,
                Sex = traineeDTO.Sex
            };
            db.Trainees.Update(trainee);
            db.Save();
            User user = db.Users.Get(traineeDTO.Login);
            if(user.Password != traineeDTO.Password)
            {
                user.Password = traineeDTO.Password;
                db.Users.Update(user);
                db.Save();
            }
        }

    }
}
