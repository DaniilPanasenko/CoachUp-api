using System;
using CoachUp.BLL.BusinessModels;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class ShortSubscribeDTO
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public CoachRate Rate { get; set; }

        public string Avatar_Link { get; set; }

        public ShortSubscribeDTO(Coach coach)
        {
            Login = coach.Login;
            Name = coach.Name;
            Surname = coach.Surname;
            Rate = new CoachRate(coach);
            Avatar_Link = coach.Avatar_Link;
        }
    }
}

