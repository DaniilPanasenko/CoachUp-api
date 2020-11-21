using System;
using System.Collections.Generic;
using System.Linq;
using CoachUp.BLL.BusinessModels;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;

namespace CoachUp.BLL.DataTransferObjects
{
    public class CoachProfileDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public char Sex { get; set; }

        public string Login { get; set; }

        public string Avatar { get; set; }

        public int Count_Subscribers { get; set; }

        public string Sport { get; set; }

        public CoachRate Rate { get; set; }

        public CoachProfileDTO(Coach coach)
        {
            Name = coach.Name;
            Surname = coach.Surname;
            Sex = coach.Sex;
            Login = coach.Login;
            Avatar = coach.Avatar_Link;
            Rate = new CoachRate(coach);
            Sport = coach.Sport.Name;
        }
    }
}
