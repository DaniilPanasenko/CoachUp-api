using System;
using CoachUp.BLL.BusinessModels;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class ShortSubscriberDTO
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public TraineeRate Rate { get; set; }

        public string Avatar_Link { get; set; }

        public ShortSubscriberDTO(Trainee trainee)
        {
            Login = trainee.Login;
            Name = trainee.Name;
            Surname = trainee.Surname;
            Rate = new TraineeRate(trainee);
            Avatar_Link = trainee.Avatar_Link;
        }
    }
}
