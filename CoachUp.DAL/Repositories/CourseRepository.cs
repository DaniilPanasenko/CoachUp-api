using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class CourseRepository : Repository<Course>, IRepository<Course>
    {
        public CourseRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
