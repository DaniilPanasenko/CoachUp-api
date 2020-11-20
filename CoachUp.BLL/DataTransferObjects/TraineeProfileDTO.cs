using System;
using System.Collections.Generic;
using System.Linq;
using CoachUp.BLL.BusinessModels;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;

namespace CoachUp.BLL.DataTransferObjects
{
    public class TraineeProfileDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public char Sex { get; set; }

        public string Login { get; set; }

        public string Avatar { get; set; }

        public int Count_Friends { get; set; }

        public int Count_Subscribes { get; set; }

        public List<string> Sports {get; set;}

        public TraineeRate Rate { get; set; }

        public TraineeProfileDTO(Trainee trainee)
        {
            Name = trainee.Name;
            Surname = trainee.Surname;
            Sex = trainee.Sex;
            Login = trainee.Login;
            Avatar = trainee.Avatar_Link;
            Sports = new List<string>();
            Rate = new TraineeRate(trainee);
        }
    }
}
