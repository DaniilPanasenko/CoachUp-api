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
    public class TrainingController : ControllerBase
    {
        private ServiceModule services;

        public TrainingController()
        {
            services = new ServiceModule();
        }

        [HttpGet("info/{id}")]
        public TrainingDTO Info(int id)
        {
            TrainingsService service = new TrainingsService(services);
            return service.Info(id);
        }

        [HttpDelete("training/{id}")]
        public void DeleteTraining(int id)
        {
            TrainingsService service = new TrainingsService(services);
            service.DeleteTraining(id);
        }

        [HttpPut("training")]
        public void EditCourse(TrainingDTO training)
        {
            TrainingsService service = new TrainingsService(services);
            service.EditTraining(training);
        }

        //[HttpHead("entercourse/{id}")]
        //public void EnterToCourse(int id)
        //{
        //    string login = HttpContext.Session.GetString("User_Login");
        //    CoursesService service = new CoursesService(services);
        //    service.EnterToCourse(login, id);
        //}

        //[HttpHead("leavecourse/{id}")]
        //public void LeaveCourse(int id)
        //{
        //    string login = HttpContext.Session.GetString("User_Login");
        //    CoursesService service = new CoursesService(services);
        //    service.LeaveCourse(login, id);
        //}

        //[HttpPost("addcomment/{id}")]
        //public void AddComment(int id, CommentDTO comment)
        //{
        //    string login = HttpContext.Session.GetString("User_Login");
        //    comment.Login = login;
        //    CommentsService service = new CommentsService(services);
        //    service.AddCourseComment(comment, id);
        //}

        //[HttpGet("comments/{id}")]
        //public List<CommentDTO> AddComment(int id, int first, int last)
        //{
        //    CommentsService service = new CommentsService(services);
        //    return service.GetCourseComments(id, first, last);
        //}

        //[HttpGet("mycourserate/{id}")]
        //public int MyCourseRate(int id)
        //{
        //    string login = HttpContext.Session.GetString("User_Login");
        //    CoursesService service = new CoursesService(services);
        //    return service.GetRate(login, id);
        //}

        //[HttpPost("addtraining/{id}")]
        //public void AddTraining(TrainingDTO training, int id)
        //{
        //    TrainingsService service = new TrainingsService(services);
        //    service.AddTraining(training, id);
        //}

        //[HttpGet("trainingslist/{id}")]
        //public TrainingDTO[] TrainingsList(int id)
        //{
        //    TrainingsService service = new TrainingsService(services);
        //    return service.TrainingsList(id);
        //}

        //[HttpPost("trainingssequence")]
        //public void ChangeTrainingsSequence(int[] sequence)
        //{
        //    TrainingsService service = new TrainingsService(services);
        //    service.ChangeTrainingsSequence(sequence);
        //}
    }
}
