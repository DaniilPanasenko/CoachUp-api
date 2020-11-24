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
using CoachUp.BLL.Infrastructure.Enums;

namespace CoachUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesListController : ControllerBase
    {
        private ServiceModule services;

        public CoursesListController()
        {
            services = new ServiceModule();
        }

        [HttpGet("courses")]
        public object Courses()
        {
            string login = HttpContext.Session.GetString("User_Login");
            if (login != null)
            {
                AuthenticationService auth = new AuthenticationService(services);
                CoursesService service = new CoursesService(services);
                bool isCoach = auth.IsCoach(login);
                if (isCoach)
                {
                    return service.GetCoursesByCoach(login);
                }
                return service.GetCoursesByUser(login);
            }
            return BadRequest();
        }

        [HttpGet("coursesbysport/{sport}")]
        public IActionResult CoursesBySport(string sport)
        {
            CoursesService service = new CoursesService(services);
            string login = HttpContext.Session.GetString("User_Login");
            if (login != null)
            {
                List<MyCourseFromListDTO> result = service.GetCoursesByUserAndSport(login, sport);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("addcourse")]
        public int AddCourse(CourseDTO course)
        {
            AuthenticationService auth = new AuthenticationService(services);
            string login = HttpContext.Session.GetString("User_Login");
            if (auth.IsCoach(login))
            {
                CoursesService service = new CoursesService(services);
                return service.AddCourse(course, login);
            }
            return 0;
        }

        [HttpGet("findcourses")]
        public object FindCourses(
            string sport,
            string name,
            string coach,
            int? rate_min,
            int? rate_max,
            int? members_min,
            int? members_max,
            int page,
            int page_size,
            SortCourses? sort,
            bool desc = false){

            CoursesService service = new CoursesService(services);
            return service.FindCourses(
                sport,
                name,
                coach,
                rate_min,
                rate_max,
                members_min,
                members_max,
                page,
                page_size,
                sort,
                desc);
        }
    }
}
