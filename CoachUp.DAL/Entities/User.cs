using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachUp.DAL.Entities
{
    public class User
    {
        [Key]
        [Required]
        [MaxLength(40)]
        public string Login { get; set; }

        [Required]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public virtual ICollection<Notification> Notifications {get; set;}

        public virtual ICollection<TrainingComment> TrainingComments { get; set; }

        public virtual ICollection<CourseComment> CourseComments { get; set; }

        public User()
        {
            Notifications = new List<Notification>();
            TrainingComments = new List<TrainingComment>();
            CourseComments = new List<CourseComment>();
        } 

    }
}
