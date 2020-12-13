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
    public class CourseController : ControllerBase
    {
        private ServiceModule services;

        public CourseController()
        {
            services = new ServiceModule();
        }

        [HttpGet("info/{id}")]
        public CourseDTO Info(int id)
        {
            CoursesService service = new CoursesService(services);
            return service.GetCourseByID(id);
        }

        [HttpDelete("course/{id}")]
        public void DeleteCourse(int id)
        {
            string login = HttpContext.Session.GetString("User_Login");
            CoursesService service = new CoursesService(services);
            service.DeleteCourse(id, login);
        }

        [HttpPut("course")]
        public void EditCourse(CourseDTO course)
        {
            string login = HttpContext.Session.GetString("User_Login");
            CoursesService service = new CoursesService(services);
            service.EditCourse(course, login);
        }

        [HttpHead("entercourse/{id}")]
        public void EnterToCourse(int id)
        {
            string login = HttpContext.Session.GetString("User_Login");
            CoursesService service = new CoursesService(services);
            service.EnterToCourse(login, id);
        }

        [HttpHead("leavecourse/{id}")]
        public void LeaveCourse(int id)
        {
            string login = HttpContext.Session.GetString("User_Login");
            CoursesService service = new CoursesService(services);
            service.LeaveCourse(login, id);
        }

        [HttpPost("comment/{id}")]
        public void AddComment(int id, CommentDTO comment)
        {
            string login = HttpContext.Session.GetString("User_Login");
            comment.Login = login;
            CommentsService service = new CommentsService(services);
            service.AddCourseComment(comment, id);
        }

        [HttpGet("comments/{id}")]
        public List<CommentDTO> Comments(int id, int first, int last)
        {
            CommentsService service = new CommentsService(services);
            return service.GetCourseComments(id,first,last);
        }

        [HttpPost("training/{id}")]
        public void AddTraining(TrainingFromListDTO training, int id)
        {
            string login = HttpContext.Session.GetString("User_Login");
            TrainingsService service = new TrainingsService(services);
            service.AddTraining(training,id, login);
        }

        [HttpGet("trainingslist/{id}")]
        public TrainingFromListDTO[] TrainingsList(int id)
        {
            TrainingsService service = new TrainingsService(services);
            return service.TrainingsList(id);
        }

        [HttpPut("trainingssequence")]
        public void ChangeTrainingsSequence(int[] sequence)
        {
            string login = HttpContext.Session.GetString("User_Login");
            TrainingsService service = new TrainingsService(services);
            service.ChangeTrainingsSequence(sequence, login);
        }
    }
}
