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
using CoachUp.DAL.Entities;

namespace CoachUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private ServiceModule services;

        public SystemController()
        {
            services = new ServiceModule();
        }

        [HttpGet("countmessages")]
        public int CountUnreadedMessages()
        {
            NotificationsService service = new NotificationsService(services);
            string login = HttpContext.Session.GetString("User_Login");
            int result = service.GetCountUnreadedMessages(login);
            return result;
        }

        [HttpGet("sportslist")]
        public List<string> GetSports()
        {
            OtherServices service = new OtherServices(services);
            return service.GetSports();
        }
    }
}

