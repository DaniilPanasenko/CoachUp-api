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
            string login = HttpContext.Session.GetString("User_Login");
            TrainingsService service = new TrainingsService(services);
            service.DeleteTraining(id, login);
        }

        [HttpPut("training")]
        public void EditCourse(TrainingDTO training)
        {
            string login = HttpContext.Session.GetString("User_Login");
            TrainingsService service = new TrainingsService(services);
            service.EditTraining(training, login);
        }

        [HttpPost("addcomment/{id}")]
        public void AddComment(int id, CommentDTO comment)
        {
            string login = HttpContext.Session.GetString("User_Login");
            comment.Login = login;
            CommentsService service = new CommentsService(services);
            service.AddTrainingComment(comment, id);
        }

        [HttpGet("comments/{id}")]
        public List<CommentDTO> AddComment(int id, int first, int last)
        {
            CommentsService service = new CommentsService(services);
            return service.GetTrainingComments(id, first, last);
        }

        [HttpGet("boxeslist/{id}")]
        public BoxDTO[] BoxesList(int id)
        {
            BoxesService service = new BoxesService(services);
            return service.BoxesList(id);
        }

        [HttpPut("boxessequence")]
        public void ChangeBoxesSequence(int[] sequence)
        {
            string login = HttpContext.Session.GetString("User_Login");
            BoxesService service = new BoxesService(services);
            service.ChangeBoxesSequence(sequence, login);
        }

        [HttpPost("addbox/{id}")]
        public void AddBox(BoxDTO box, int id)
        {
            string login = HttpContext.Session.GetString("User_Login");
            BoxesService service = new BoxesService(services);
            service.AddBox(box, id, login);
        }

        [HttpDelete("box/{id}")]
        public void DeleteBox(int id)
        {
            string login = HttpContext.Session.GetString("User_Login");
            BoxesService service = new BoxesService(services);
            service.DeleteBox(id, login);
        }






    }
}
