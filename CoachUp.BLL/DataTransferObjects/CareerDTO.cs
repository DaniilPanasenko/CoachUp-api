using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class CareerDTO
    {
        public int ID { get; set; }

        public int SYear { get; set; }

        public int FYear { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

        public CareerDTO()
        {
        }

        public CareerDTO(Career career)
        {
            ID = career.ID;
            SYear = career.SYear;
            FYear = career.FYear;
            Company = career.Company;
            Position = career.Position;
            Description = career.Description;
        }
    }
}
