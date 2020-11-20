using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoachUp.BLL;
using CoachUp.BLL.Infrastructure;
using CoachUp.BLL.Services;
using CoachUp.BLL.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace CoachUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private ServiceModule services;

        public AuthenticationController()
        {
            services = new ServiceModule();
        }

        [HttpPost("login")]
        public string Login(UserDTO user)
        {

            AuthenticationService authentication = new AuthenticationService(services);
            string status = authentication.Login(user);
            if (status == "OK")
            {
                HttpContext.Session.SetString("User_Login", user.Login);
            }
            return status;

        }

        [HttpPost("regisration")]
        public string Registration(PersonDTO user)
        {
            AuthenticationService authentication = new AuthenticationService(services);
            string status = authentication.Registration(user);
            if (status == "OK")
            {
                HttpContext.Session.SetString("User_Login", user.Login);
            }
            return status;
        }

        [HttpHead("logout")]
        public void LogOut()
        {
            HttpContext.Session.Remove("User_Login");
        }
    }
}
