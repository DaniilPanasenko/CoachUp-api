using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class TrainingComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Comment { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int? Reply_Comment_ID { get; set; }

        [ForeignKey("Reply_Comment_ID")]
        public virtual TrainingComment Reply_Comment { get; set; }

        [Required]
        public int Training_Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string User_Login { get; set; }

        [ForeignKey("User_Login")]
        public virtual User User { get; set; }

        [ForeignKey("Training_Id")]
        public virtual Training Training { get; set; }

        public virtual ICollection<TrainingComment> Reply_Comments {get; set;}

        public TrainingComment()
        {
            Reply_Comments = new List<TrainingComment>();
        }

    }
}
