using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.BusinessModels
{
    public class CourseComplete
    {
        public int Percent { get; set; }
        public int Place { get; set; }
        public CourseComplete(Trainee trainee, Course course)
        {
            Percent = 78;
            Place = 1;
        }
    }
}
