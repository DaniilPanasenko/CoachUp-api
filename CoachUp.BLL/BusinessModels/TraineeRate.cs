using System;
namespace CoachUp.BLL.BusinessModels
{
    public class TraineeRate
    {
        public int Place { get; set; }
        public int Points { get; set; }

        public TraineeRate(DAL.Entities.Trainee trainee)
        {
            Place = 1;
            Points = 100;
        }
    }
}
