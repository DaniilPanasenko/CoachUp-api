using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;
using System.Linq;


namespace CoachUp.DAL.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(CoachUpContext context) : base(context)
        {
        }

        public void Delete(string login)
        {
            User user = db.Users.Find(login);
            if (user != null)
                db.Users.Remove(user);
        }

        public User Get(string login)
        {
            return db.Users.Find(login);
        }

    }
}
