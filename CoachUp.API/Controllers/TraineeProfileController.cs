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
    public class TraineeProfileController : ControllerBase
    {
        private ServiceModule services;

        public TraineeProfileController()
        {
            services = new ServiceModule();
        }

        [HttpHead("openprofile/{login}")]
        public void OpenProfile(string login)
        {
            HttpContext.Session.SetString("TraineeProfile_Login", login);
        }

        [HttpGet("info")]
        public TraineeProfileDTO Info()
        {
            TraineeProfileService service = new TraineeProfileService(services);
            string login = HttpContext.Session.GetString("TraineeProfile_Login");
            TraineeProfileDTO result = service.GetInfo(login);
            return result;
        }

        [HttpGet("coursesbysport/{sport}")]
        public List<MyCourseFromListDTO> CoursesBySport(string sport)
        {
            CoursesService service = new CoursesService(services);
            string login = HttpContext.Session.GetString("TraineeProfile_Login");
            List<MyCourseFromListDTO> result = service.GetCoursesByUserAndSport(login, sport);
            return result;
        }

        [HttpGet("friendstop20")]
        public List<ShortFriendDTO> FriendsTop20()
        {
            FriendsService service = new FriendsService(services);
            string login = HttpContext.Session.GetString("TraineeProfile_Login");
            List<ShortFriendDTO> result = service.GetTop20Friens(login);
            return result;
        }

        [HttpGet("subscribestop20")]
        public List<ShortSubscribeDTO> SubscribesTop20()
        {
            SubscribesService service = new SubscribesService(services);
            string login = HttpContext.Session.GetString("TraineeProfile_Login");
            List<ShortSubscribeDTO> result = service.GetTop20Subscribes(login);
            return result;
        }

        [HttpHead("friendrequest")]
        public void FriendRequest()
        {
            string me = HttpContext.Session.GetString("User_Login");
            string friend = HttpContext.Session.GetString("TraineeProfile_Login");
            FriendsService service = new FriendsService(services);
            service.AddFriend(me, friend);
        }

        [HttpPut("edit")]
        public void Edit(TraineeDTO new_me)
        {
            TraineeProfileService service = new TraineeProfileService(services);
            service.EditProfile(new_me);
        }
    }
}
