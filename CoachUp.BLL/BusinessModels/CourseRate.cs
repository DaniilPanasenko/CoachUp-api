using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.BusinessModels
{
    public class CourseRate
    {
        public int Place { get; set; }
        public int Points { get; set; }

        public CourseRate(Course course)
        {
            Place = 1;
            Points = 100;
        }
    }
}
