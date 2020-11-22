using System;
using CoachUp.BLL.BusinessModels;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class TrainingDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Course { get; set; }

        public int Num_In_Course { get; set; }

        public TrainingDTO()
        {
        }

        public TrainingDTO(Training training)
        {
            ID = training.ID;
            Name = training.Name;
            Description = training.Description;
            Course = training.Course.Name;
            Num_In_Course = training.Num_in_Course;
        }
    }
}