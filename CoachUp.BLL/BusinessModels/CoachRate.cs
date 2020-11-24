using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.BusinessModels
{
    public class CoachRate
    {
        public int Points { get; set; }

        public int Place { get; set; }

        public CoachRate(Coach coach)
        {
            Points = coach.Subscribes.Count;
        }

    }
}
