using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Link { get; set; }

        [Required]
        public int Box_ID { get; set; }

        [ForeignKey("Box_ID")]
        public virtual Box Box { get; set; }

    }
}
