using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(40)]
        public string Coach_Login { get; set; }

        [ForeignKey("Coach_Login")]
        public virtual Coach Coach { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }

        public Course()
        {
            Members = new List<Member>();
            Trainings = new List<Training>();
        }
    }
}
