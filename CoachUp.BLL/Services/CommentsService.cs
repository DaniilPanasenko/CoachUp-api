using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class CommentsService
    {
        private UnitOfWork db;
        private ServiceModule sm;
        public CommentsService(ServiceModule _sm)
        {
            db = _sm.DB;
            sm = _sm;
        }

        public void AddCourseComment(CommentDTO commentDTO, int id)
        {
            CourseComment comment = new CourseComment()
            {
                Comment = commentDTO.Message,
                DateTime = DateTime.Now,
                Reply_Comment_ID = commentDTO.Reply_ID,
                User_Login = commentDTO.Login,
                Course_Id = id
            };
            db.CourseComments.Create(comment);
            db.Save();
        }

        public List<CommentDTO> GetCourseComments(int course, int first, int last)
        {
            List<CourseComment> comments = db.CourseComments
                .Find(x => x.Course_Id == course && x.Reply_Comment_ID == null)
                .OrderBy(x => x.DateTime)
                .ToList();
            List<CommentDTO> result = new List<CommentDTO>();
            foreach (CourseComment comment0 in comments)
            {
                result.Add(new CommentDTO(comment0) { Level = 0 });
                foreach (CourseComment comment1 in comment0.Reply_Comments)
                {
                    result.Add(new CommentDTO(comment1) { Level = 1 });
                    foreach (CourseComment comment2 in comment1.Reply_Comments)
                    {
                        result.Add(new CommentDTO(comment2) { Level = 2 });
                        foreach (CourseComment comment3 in comment2.Reply_Comments)
                        {
                            result.Add(new CommentDTO(comment3) { Level = 3 });
                        }
                    }
                }
            }
            result = result.Skip(first).Take(last - first + 1).ToList();
            foreach (CommentDTO comment in result)
            {
                Coach coach = db.Coaches.Get(comment.Login);
                if (coach == null)
                {
                    Trainee trainee = db.Trainees.Get(comment.Login);
                    comment.Avatar = trainee.Avatar_Link;
                }
                else
                {
                    comment.Avatar = coach.Avatar_Link;
                }
            }
            return result;
        }
    }
}
