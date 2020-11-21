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
    public class CoachCourseController : ControllerBase
    {
        private ServiceModule services;

        public CoachCourseController()
        {
            services = new ServiceModule();
        }

        [HttpDelete("deletecourse/{id}")]
        public void DeleteCourse(int id)
        {
            CoursesService service = new CoursesService(services);
            service.DeleteCourse(id);
        }
    }
}
