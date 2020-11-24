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
using CoachUp.BLL.BusinessModels;

namespace CoachUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotionController : ControllerBase
    {
        private ServiceModule services;

        public MotionController()
        {
            services = new ServiceModule();
        }

        [HttpGet("marks/{box_id}")]
        public MotionComplete GetMotionComplete(int box_id)
        {
            StatisticService service = new StatisticService(services);
            AuthenticationService auth = new AuthenticationService(services);
            string login = HttpContext.Session.GetString("User_Login");
            if(login!=null && !auth.IsCoach(login))
            {
                return service.GetMotionStatisticByUser(login, box_id);
            }
            return null;
        }

        [HttpGet("professionalmotions/{id}")]
        public List<string> GetProfesionalMotions(int id)
        {
            MotionService service = new MotionService(services);
            return service.GetProfessionalMotion(id);
        }

        [HttpPost("professionalmotion/{id}")]
        public void AddProfessionalMotion(int id, [FromBody]string file)
        {
            MotionService service = new MotionService(services);
            service.AddProfessionalMotion(id, file);
        }

        [HttpPost("traineemotion/{id}/{login}/{persent}")]
        public void AddTraineeeMotion(int id, string login, int persent, [FromBody] string file)
        {
            MotionService service = new MotionService(services);
            service.AddTraineeMotion(id, login, file, persent);
        }
    }
}

