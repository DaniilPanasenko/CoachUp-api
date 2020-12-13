using System;
using System.Linq;
using CoachUp.BLL.BusinessModels;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class CoachCourseFromListDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }


        public int Count_members { get; set; }

        public CoachCourseFromListDTO(Course course)
        {
            ID = course.ID;
            Name = course.Name;
            Count_members = course.Members.Count();
        }
    }
}
