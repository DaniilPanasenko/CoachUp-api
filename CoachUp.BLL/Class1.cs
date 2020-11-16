using System;
using System.Collections.Generic;
using System.Linq;
using CoachUp.DAL;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;
using CoachUp.DAL.Repositories;

namespace CoachUp.BLL
{
    public class Class1
    {
        public string Hi()
        {
            UnitOfWork db = new UnitOfWork();
           
            return db.Subscribes.GetAll().ToList().First().Coach_Login;
        }
    }
}
