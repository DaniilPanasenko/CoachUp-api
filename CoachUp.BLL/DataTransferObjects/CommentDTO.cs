using System;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.DataTransferObjects
{
    public class CommentDTO
    {
        public int ID { get; set; }

        public string Message { get; set; }

        public DateTime DateTime { get; set; } 

        public int? Reply_ID { get; set; }

        public string Login { get; set; }

        public int Level { get; set; }

        public string Avatar { get; set; }

        public CommentDTO()
        {
        }

        public CommentDTO(CourseComment comment)
        {
            ID = comment.ID;
            Message = comment.Comment;
            DateTime = comment.DateTime;
            Reply_ID = comment.Reply_Comment_ID;
            Login = comment.User_Login;
        }

        public CommentDTO(TrainingComment comment)
        {
            ID = comment.ID;
            Message = comment.Comment;
            DateTime = comment.DateTime;
            Reply_ID = comment.Reply_Comment_ID;
            Login = comment.User_Login;
        }
    }
}
