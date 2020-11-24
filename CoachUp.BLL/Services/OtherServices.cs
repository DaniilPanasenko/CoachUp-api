using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class OtherServices
    {
        private UnitOfWork db;
        public OtherServices(ServiceModule sm)
        {
            db = sm.DB;
        }

        public List<string> GetSports()
        {
            return db.Sports.GetAll().Select(x => x.Name).ToList();
        }

    }
}