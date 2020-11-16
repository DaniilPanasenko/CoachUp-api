using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Friend
    {
        [Required]
        [MaxLength(40)]
        public string Trainee1_Login { get; set; }

        [ForeignKey("Trainee1_Login")]
        public virtual Trainee Trainee1 { get; set; }

        [Required]
        [MaxLength(40)]
        public string Trainee2_Login { get; set; }

        [ForeignKey("Trainee2_Login")]
        public virtual Trainee Trainee2 { get; set; }

        [Required]
        public bool Accepted { get; set; }
    }
}
