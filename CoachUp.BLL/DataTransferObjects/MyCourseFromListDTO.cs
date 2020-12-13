using System;
using CoachUp.BLL.BusinessModels;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class MyCourseFromListDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public object Coach { get; set; }

        public MyCourseFromListDTO(Course course, Trainee trainee)
        {
            ID = course.ID;
            Name = course.Name;
            Coach = new
            {
                Name = course.Coach.Name,
                Surname = course.Coach.Surname
            };
        }
    }
}
