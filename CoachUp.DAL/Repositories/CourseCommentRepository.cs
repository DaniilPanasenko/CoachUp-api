using System;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class CourseCommentRepository : Repository<CourseComment>, IRepository<CourseComment>
    {
        public CourseCommentRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
