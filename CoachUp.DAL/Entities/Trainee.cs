using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CoachUp.DAL.Entities
{
    public class Trainee
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
        public char Sex { get; set; }

        [MaxLength(100)]
        public string Avatar_Link { get; set; }

        [ForeignKey("Login")]
        public virtual User User { get; set; }

        public virtual ICollection<Subscribe> Subscribes { get; set; }

        public virtual ICollection<Member> Member_in_Courses { get; set; }

        [InverseProperty("Trainee1")]
        public virtual ICollection<Friend> FriendsSend { get; set; }

        [InverseProperty("Trainee2")]
        public virtual ICollection<Friend> FriendsRequest { get; set; }

        public Trainee()
        {
            Subscribes = new List<Subscribe>();
            Member_in_Courses = new List<Member>();
            FriendsSend = new List<Friend>();
            FriendsRequest = new List<Friend>();
        }
    }
}
