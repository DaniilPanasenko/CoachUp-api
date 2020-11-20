using System;
using System.Collections.Generic;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoachUp.DAL.Repositories
{
    public class CourseRepository : Repository<Course>, IRepository<Course>
    {
        public CourseRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
