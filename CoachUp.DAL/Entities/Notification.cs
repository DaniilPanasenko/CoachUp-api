using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Notification
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Messge { get; set; }

        [Required]
        [MaxLength(40)]
        public string User_Login { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public bool IsRead { get; set; }

        [ForeignKey("User_Login")]
        public virtual User User { get; set; }
    }
}
