using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int Rate { get; set; }

        [Required]
        public int Course_Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Trainee_Login { get; set; }

        [ForeignKey("Trainee_Login")]
        public virtual Trainee Trainee { get; set; }

        [ForeignKey("Course_Id")]
        public virtual Course Course { get; set; }

        public virtual ICollection<TraineeMotion> TraineeMotions { get; set; }

        public Member()
        {
            TraineeMotions = new List<TraineeMotion>();
        }
    }
}
