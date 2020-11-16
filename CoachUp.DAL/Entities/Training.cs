using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Training
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public int Num_in_Course { get; set; }

        [Required]
        public int Course_ID { get; set; }

        [ForeignKey("Course_ID")]
        public virtual Course Course { get; set; }

        public virtual ICollection<Box> Boxes { get; set; }

        public Training()
        {
            Boxes = new List<Box>();
        }
    }
}
