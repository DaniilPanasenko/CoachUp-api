using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class TraineeMotion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int Member_ID { get; set; }

        [Required]
        public int Motion_ID { get; set; }

        [ForeignKey("Motion_ID")]
        public virtual Motion Motion { get; set; }

        [ForeignKey("Member_ID")]
        public virtual Member Member { get; set; }

        [Required]
        [MaxLength(10000)]
        public string File { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int Persent { get; set; }
    }
}