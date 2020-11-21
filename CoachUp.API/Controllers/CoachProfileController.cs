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

        [HttpHead("openprofile/{login}")]
        public void OpenProfile(string login)
        {
            HttpContext.Session.SetString("CoachProfile_Login", login);
        }

        [HttpGet("info")]
        public CoachProfileDTO Info()
        {
            CoachProfileService service = new CoachProfileService(services);
            string login = HttpContext.Session.GetString("CoachProfile_Login");
            CoachProfileDTO result = service.GetInfo(login);
            return result;
        }

        [HttpGet("courses")]
        public List<CoachCourseFromListDTO> Courses()
        {
            CoursesService service = new CoursesService(services);
            string login = HttpContext.Session.GetString("CoachProfile_Login");
            List<CoachCourseFromListDTO> result = service.GetCoursesByCoach(login);
            return result;
        }

        [HttpGet("subscriberstop20")]
        public List<ShortSubscriberDTO> SubscribersTop20()
        {
            SubscribesService service = new SubscribesService(services);
            string login = HttpContext.Session.GetString("CoachProfile_Login");
            List<ShortSubscriberDTO> result = service.GetTop20Subscribers(login);
            return result;
        }

        [HttpHead("subscribing")]
        public void Subscribing()
        {
            string me = HttpContext.Session.GetString("User_Login");
            string coach = HttpContext.Session.GetString("CoachProfile_Login");
            SubscribesService service = new SubscribesService(services);
            service.AddSubscribe(me, coach);
        }

        [HttpPut("edit")]
        public void Edit(CoachDTO new_me)
        {
            CoachProfileService service = new CoachProfileService(services);
            service.EditProfile(new_me);
        }

        [HttpGet("career")]
        public List<CareerDTO> Career()
        {
            string coach = HttpContext.Session.GetString("CoachProfile_Login");
            CoachProfileService service = new CoachProfileService(services);
            return service.GetCareer(coach);
        }

        [HttpPost("career")]
        public List<CareerDTO> AddCareer(CareerDTO career)
        {
            string coach = HttpContext.Session.GetString("CoachProfile_Login");
            CoachProfileService service = new CoachProfileService(services);
            service.AddCareer(career, coach);
            return service.GetCareer(coach);
        }

        [HttpDelete("career/{id}")]
        public void DeleteCareer(int id)
        {
            CoachProfileService service = new CoachProfileService(services);
            service.DeleteCareer(id);
        }
    }
}
