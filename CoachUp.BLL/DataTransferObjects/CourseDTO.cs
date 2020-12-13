using System;
using CoachUp.BLL.BusinessModels;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class CourseDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CoachName { get; set; }

        public string CoachSurname { get; set; }

        public string CoachLogin { get; set; }

        public string Sport { get; set; }

        public int CourseMember { get; set; }

        public CourseDTO()
        {
        }

        public CourseDTO(Course course)
        {
            ID = course.ID;
            Name = course.Name;
            Description = course.Description;
            CoachName = course.Coach.Name;
            CoachSurname = course.Coach.Surname;
            CoachLogin = course.Coach.Login;
            Sport = course.Coach.Sport.Name;
            CourseMember = course.Members.Count;
        }
    }
}
