using System;
using CoachUp.BLL.BusinessModels;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class TrainingFromListDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TrainingFromListDTO()
        {
        }

        public TrainingFromListDTO(Training training)
        {
            ID = training.ID;
            Name = training.Name;
            Description = training.Description;
        }
    }
}
