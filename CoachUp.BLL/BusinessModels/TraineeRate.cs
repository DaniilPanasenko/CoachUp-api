using System;
using System.Collections.Generic;
using System.Linq;
using CoachUp.DAL.Entities;

namespace CoachUp.BLL.BusinessModels
{
    public class TraineeRate
    {
        public int Place { get; set; }

        public int Points { get; set; }

        public TraineeRate(Trainee trainee)
        {
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
            List<Member> members = trainee.Member_in_Courses.ToList();
            foreach(Member member in members)
            {
                List<TraineeMotion> motions = member.TraineeMotions
                    .OrderBy(x=>x.DateTime)
                    .ToList();
                foreach(TraineeMotion motion in motions)
                {
                    bool has_key = dictionary.Keys
                        .Any(x => x.Equals(motion.Motion_ID));
                    if (!has_key)
                    {
                        dictionary.Add(motion.Motion_ID, new List<int>());
                    }
                    dictionary[motion.Motion_ID].Add(motion.Persent);
                }
            }
            int sum = 0;
            foreach(KeyValuePair<int, List<int>> marks in dictionary)
            {
                sum += new MotionComplete(marks.Value.ToArray(), trainee.Login).Summary;
            }
            Points = sum;
        }
    }
}
