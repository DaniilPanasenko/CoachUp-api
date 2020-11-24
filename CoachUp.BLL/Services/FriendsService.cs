using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class FriendsService
    {
        private UnitOfWork db;
        private ServiceModule sm;
        public FriendsService(ServiceModule _sm)
        {
            db = _sm.DB;
            sm = _sm;
        }

        public List<ShortFriendDTO> GetTop20Friends(string login)
        {
            
            Trainee trainee = db.Trainees.Get(login);
            if (trainee != null)
            {
                List<Trainee> friends1 = trainee.FriendsRequest
                    .Where(x => x.Accepted)
                    .Select(x => x.Trainee1)
                    .ToList();

                List<Trainee> friends2 = trainee.FriendsSend
                    .Where(x => x.Accepted)
                    .Select(x => x.Trainee2)
                    .ToList();

                List<ShortFriendDTO> friends = friends1
                    .Concat(friends2)
                    .Select(x => new ShortFriendDTO(x))
                    .OrderByDescending(x => x.Rate.Points)
                    .Take(20)
                    .ToList();

                return friends;
            }
            return null;
        }

        public void AddFriend(string my_login, string friend_login)
        {
            Trainee me = db.Trainees.Get(my_login);
            Trainee friend = db.Trainees.Get(friend_login);
            Friend friend0 = db.Friends
                .Find(x =>
                (x.TraineeOne_Login == my_login &&
                x.TraineeTwo_Login == friend_login) ||
                (x.TraineeTwo_Login == my_login &&
                x.TraineeOne_Login == friend_login))
                .FirstOrDefault();
            if (me != null && friend != null && friend0 == null)
            {
                NotificationsService service = new NotificationsService(sm);
                service.AddNotification($"User {me.Login} want to be friends", friend_login);
                Friend new_friend = new Friend()
                {
                    Trainee1 = me,
                    Trainee2 = friend,
                    Accepted = false
                };
                db.Friends.Create(new_friend);
                db.Save();
            }
        }

    }
}
