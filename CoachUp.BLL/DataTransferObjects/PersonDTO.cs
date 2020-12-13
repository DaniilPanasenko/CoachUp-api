using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class PersonDTO : UserDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Surname { get; set; }

        public char Sex { get; set; }

        public string Sport { get; set; }

        public bool IsCoach { get; set; }

        public string Avatar_Link { get; set; }

    }
}
