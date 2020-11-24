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
    public class CoachProfileController : ControllerBase
    {
        private ServiceModule services;

        public CoachProfileController()
        {
            services = new ServiceModule();
        }

        [HttpGet("info/{login}")]
        public CoachProfileDTO Info(string login)
        {
            CoachProfileService service = new CoachProfileService(services);
            CoachProfileDTO result = service.GetInfo(login);
            return result;
        }

        [HttpGet("courses/{login}")]
        public List<CoachCourseFromListDTO> Courses(string login)
        {
            CoursesService service = new CoursesService(services);
            List<CoachCourseFromListDTO> result = service.GetCoursesByCoach(login);
            return result;
        }

        [HttpGet("subscriberstop20/{login}")]
        public List<ShortSubscriberDTO> SubscribersTop20(string login)
        {
            SubscribesService service = new SubscribesService(services);
            List<ShortSubscriberDTO> result = service.GetTop20Subscribers(login);
            return result;
        }

        [HttpHead("subscribing/{login}")]
        public void Subscribing(string login)
        {
            string me = HttpContext.Session.GetString("User_Login");
            SubscribesService service = new SubscribesService(services);
            service.AddSubscribe(me, login);
        }

        [HttpPut("edit")]
        public void Edit(CoachDTO new_me)
        {
            string login = HttpContext.Session.GetString("User_Login");
            if (login == new_me.Login)
            {
                CoachProfileService service = new CoachProfileService(services);
                service.EditProfile(new_me);
            }
        }

        [HttpGet("career/{login}")]
        public List<CareerDTO> Career(string login)
        {
            CoachProfileService service = new CoachProfileService(services);
            return service.GetCareer(login);
        }

        [HttpPost("career")]
        public void AddCareer(CareerDTO career)
        {
            AuthenticationService authentication = new AuthenticationService(services);
            string coach = HttpContext.Session.GetString("User_Login");
            if (authentication.IsCoach(coach))
            {
                CoachProfileService service = new CoachProfileService(services);
                service.AddCareer(career, coach);
            }
        }

        [HttpDelete("career/{id}")]
        public void DeleteCareer(int id)
        {
            string coach = HttpContext.Session.GetString("User_Login");
            CoachProfileService service = new CoachProfileService(services);
            service.DeleteCareer(id, coach);
        }
    }
}
