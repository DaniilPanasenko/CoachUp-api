using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class CoachProfileService
    {
        private UnitOfWork db;
        public CoachProfileService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public CoachProfileDTO GetInfo(string login)
        {
            Coach coach = db.Coaches.Get(login);
            CoachProfileDTO profile = new CoachProfileDTO(coach);
            profile.Count_Subscribers = coach.Subscribes.Count();
            return profile;
        }

        public void EditProfile(CoachDTO coachDTO)
        {
            Coach coach = new Coach
            {
                Login = coachDTO.Login,
                Avatar_Link = coachDTO.Avatar_Link,
                Name = coachDTO.Name,
                Surname = coachDTO.Surname,
                Sex = coachDTO.Sex,
                Sport_ID = db.Sports
                .Find(x => x.Name == coachDTO.Sport)
                .First().ID,
                Description = coachDTO.Description
            };
            db.Coaches.Update(coach);
            db.Save();
            User user = db.Users.Get(coachDTO.Login);
            if (user.Password != coachDTO.Password)
            {
                user.Password = coachDTO.Password;
                db.Users.Update(user);
                db.Save();
            }
        }

        public List<CareerDTO> GetCareer(string login)
        {
            return db.Careers
                .Find(x => x.Coach_Login == login)
                .Select(x => new CareerDTO(x))
                .OrderBy(x => x.SYear)
                .ThenBy(x => x.FYear)
                .ToList();
        }

        public void AddCareer(CareerDTO career, string login)
        {
            Career career1 = new Career
            {
                Company = career.Company,
                Coach_Login = login,
                Description = career.Description,
                SYear = career.SYear,
                FYear = career.FYear,
                Position = career.Position
            };
            db.Careers.Create(career1);
            db.Save();
        }

        public void DeleteCareer(int id)
        {
            db.Careers.Delete(id);
            db.Save();
        }
    }

}
