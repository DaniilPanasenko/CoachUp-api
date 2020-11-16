using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachUp.DAL.Entities
{
    public class Coach
    {
        [Key]
        [Required]
        [MaxLength(40)]
        public string Login { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }

        [Required]
        public char Sex{ get; set; }

        [MaxLength(100)]
        public string Avatar_Link { get; set; }

        [Required]
        public int Sport_ID { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("Login")]
        public virtual User User { get; set; }

        [ForeignKey("Sport_ID")]
        public virtual Sport Sport { get; set; }

        public virtual ICollection<Subscribe> Subscribes { get; set; }

        public virtual ICollection<Career> Careers { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Coach()
        {
            Subscribes = new List<Subscribe>();
            Careers = new List<Career>();
            Courses = new List<Course>();
        }
    }
}
