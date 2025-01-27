﻿using System.Linq;
using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;

namespace CoachUp.BLL.Services
{
    public class AuthenticationService
    {
        private UnitOfWork db;
        public AuthenticationService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public string Login(UserDTO input_user)
        {
            if(input_user.Login==null || input_user.Password == null)
            {
                return "BadRequest";
            }
            User user = db.Users.Get(input_user.Login);
            if (user == null)
            {
                return "Invalid login";
            }
            if (user.Password != input_user.Password)
            {
                return "Invalid password";
            }
            return "OK";
        }

        public string Registration(PersonDTO input_user)
        {
            if (input_user.Login == null ||
                input_user.Password == null ||
                input_user.Email==null ||
                input_user.Name==null ||
                input_user.Surname==null||
                input_user.Sex == null ||
                (input_user.IsCoach ==true &&
                input_user.Sport==null))
            {
                return "BadRequest";
            }
            User user = db.Users.Get(input_user.Login);
            if (user != null)
            {
                return "The user with this login already exist";
            }
            User user_email = db.Users
                .Find(x => x.Email == input_user.Email)
                .FirstOrDefault();
            if (user_email != null)
            {
                return "The user with this email already exist";
            }

            User new_user = new User()
            {
                Login = input_user.Login,
                Password = input_user.Password,
                Email = input_user.Email
            };
            db.Users.Create(new_user);

            if (input_user.IsCoach)
            {
                Coach coach = new Coach()
                {
                    Name = input_user.Name,
                    Surname = input_user.Surname,
                    User = new_user,
                    Sport_ID = db.Sports.Find(x => x.Name == input_user.Sport).First().ID,
                    Sex = input_user.Sex
                };
                db.Coaches.Create(coach);
            }
            else
            {
                Trainee trainee = new Trainee()
                {
                    Name = input_user.Name,
                    Surname = input_user.Surname,
                    User = new_user,
                    Sex = input_user.Sex
                };
                db.Trainees.Create(trainee);
            }
            db.Save();
            return "OK";
        }

        public bool IsCoach(string login)
        {
            return db.Coaches.Get(login) != null;
        }

        public string GetAvatar(string login)
        {
            if (IsCoach(login))
            {
                return db.Coaches.Get(login).Avatar_Link;
            }
            return db.Trainees.Get(login).Avatar_Link;
        }
    }
}
