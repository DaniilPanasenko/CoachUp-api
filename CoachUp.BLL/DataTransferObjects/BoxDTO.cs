using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class BoxDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public bool IsMedia { get; set; }

        public int Num_in_Training { get; set; }

        public string Link { get; set; }

        public BoxDTO()
        {

        }
        public BoxDTO(Box box)
        {
            ID = box.ID;
            Name = box.Name;
            Text = box.Description;
            Num_in_Training = box.Num_in_Training;
            IsMedia = false;
        }
    }
}
