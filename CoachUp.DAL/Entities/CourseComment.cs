using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class CourseComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Comment { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int Reply_Comment_ID { get; set; }

        [ForeignKey("Reply_Comment_ID")]
        public virtual CourseComment Reply_Comment { get; set; }

        [Required]
        public int Course_Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string User_Login { get; set; }

        [ForeignKey("User_Login")]
        public virtual User User { get; set; }

        [ForeignKey("Course_Id")]
        public virtual Course Course { get; set; }

        public virtual ICollection<CourseComment> Reply_Comments { get; set; }

        public CourseComment()
        {
            Reply_Comments = new List<CourseComment>();
        }
    }
}
