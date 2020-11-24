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

        [HttpGet("info/{login}")]
        public TraineeProfileDTO Info(string login)
        {
            TraineeProfileService service = new TraineeProfileService(services);
            TraineeProfileDTO result = service.GetInfo(login);
            return result;
        }

        [HttpGet("coursesbysport/{login}/{sport}")]
        public List<MyCourseFromListDTO> CoursesBySport(string login, string sport)
        {
            CoursesService service = new CoursesService(services);
            List<MyCourseFromListDTO> result = service.GetCoursesByUserAndSport(login, sport);
            return result;
        }

        [HttpGet("friendstop20/{login}")]
        public List<ShortFriendDTO> FriendsTop20(string login)
        {
            FriendsService service = new FriendsService(services);
            List<ShortFriendDTO> result = service.GetTop20Friends(login);
            return result;
        }

        [HttpGet("subscribestop20/{login}")]
        public List<ShortSubscribeDTO> SubscribesTop20(string login)
        {
            SubscribesService service = new SubscribesService(services);
            List<ShortSubscribeDTO> result = service.GetTop20Subscribes(login);
            return result;
        }

        [HttpHead("friendrequest/{friend}")]
        public void FriendRequest(string friend)
        {
            string me = HttpContext.Session.GetString("User_Login");
            FriendsService service = new FriendsService(services);
            service.AddFriend(me, friend);
        }

        [HttpPut("edit")]
        public void Edit(TraineeDTO new_me)
        {
            string login = HttpContext.Session.GetString("User_Login");
            if (login == new_me.Login)
            {
                TraineeProfileService service = new TraineeProfileService(services);
                service.EditProfile(new_me);
            }
        }
    }
}
