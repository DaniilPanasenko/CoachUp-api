using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Career
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int SYear { get; set; }

        public int FYear { get; set; }

        [Required]
        [MaxLength(40)]
        public string Coach_Login { get; set; }

        [MaxLength(100)]
        public string Company { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("Coach_Login")]
        public virtual Coach Coach { get; set; }
    }
}
