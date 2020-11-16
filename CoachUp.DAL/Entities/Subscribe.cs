using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CoachUp.DAL.Entities
{
    public class Subscribe
    {
        [Required]
        [MaxLength(40)]
        public string Trainee_Login { get; set; }

        [ForeignKey("Trainee_Login")]
        public virtual Trainee Trainee { get; set; }

        [Required]
        [MaxLength(40)]
        public string Coach_Login { get; set; }

        [ForeignKey("Coach_Login")]
        public virtual Coach Coach { get; set; }
    }
}
