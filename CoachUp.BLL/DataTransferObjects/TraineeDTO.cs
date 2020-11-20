using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class TraineeDTO : UserDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public char Sex { get; set; }

        public string Avatar_Link { get; set; }

    }
}
