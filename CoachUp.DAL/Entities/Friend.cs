using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Friend
    {
        [Required]
        [MaxLength(40)]
        public string TraineeOne_Login { get; set; }

        [ForeignKey("TraineeOne_Login")]
        public virtual Trainee Trainee1 { get; set; }

        [Required]
        [MaxLength(40)]
        public string TraineeTwo_Login { get; set; }

        [ForeignKey("TraineeTwo_Login")]
        public virtual Trainee Trainee2 { get; set; }

        [Required]
        public bool Accepted { get; set; }
    }
}
