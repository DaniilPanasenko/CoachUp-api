using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Motion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int Box_ID { get; set; }

        [ForeignKey("Box_ID")]
        public virtual Box Box { get; set; }

        public virtual ICollection<TraineeMotion> TraineeMotions { get; set; }

        public virtual ICollection<ProffesionalMotion> ProffesionalMotions { get; set; }

        public Motion()
        {
            TraineeMotions = new List<TraineeMotion>();
            ProffesionalMotions = new List<ProffesionalMotion>();
        }

    }
}
