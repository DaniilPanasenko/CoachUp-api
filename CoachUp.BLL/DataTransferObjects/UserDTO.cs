using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class UserDTO
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(User user)
        {
            Login = user.Login;
            Password = user.Password;
        }
    }
}
