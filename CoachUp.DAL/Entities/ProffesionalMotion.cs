using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class ProffesionalMotion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int Motion_ID { get; set; }

        [ForeignKey("Motion_ID")]
        public virtual Motion Motion { get; set; }

        [Required]
        [MaxLength(10000)]
        public string File { get; set; }

    }
}