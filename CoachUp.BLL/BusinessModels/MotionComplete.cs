using System;
using System.Collections.Generic;
using System.Linq;
using CoachUp.DAL.Repositories;

namespace CoachUp.BLL.BusinessModels
{
    public class MotionComplete
    {
        public string Login { get; set; }

        public int Summary { get; set; }

        public int Max { get; set; }

        public int Place { get; set; }

        public List<MotionComplete> Friends { get; set; }


        public MotionComplete(int[] marks, string login)
        {
            this.Login = login;
            this.GetMark(marks);
        }

        public void GetMark(int[] marks)
        {
            const int countable_marks = 30;
            if (marks.Length != 0)
            {
                int[] temp_marks = new int[1];
                for (int i = 0; i < marks.Length; i++)
                {
                    if (marks[i] > Max)
                    {
                        Max = marks[i];
                    }
                }
                temp_marks[0] = Max;
                for (int i = marks.Length - 1; i >= 0; i--)
                {
                    if (marks[i] == Max)
                    {
                        for (int j = i; j < marks.Length - 1; j++)
                        {
                            marks[j] = marks[j + 1];
                        }
                        Array.Resize(ref marks, marks.Length - 1);
                    }
                }
                if (marks.Length > countable_marks)
                {
                    Array.Resize(ref marks, countable_marks);
                }
                int current_size = 2;
                for (int i = 0; i < marks.Length; i++)
                {
                    int sum = 0;
                    int count = 0;
                    bool end = false;
                    for (int j = i; j < marks.Length; j++)
                    {
                        if (count < current_size)
                        {
                            sum += marks[j];
                            count++;
                        }
                        if (count==current_size)
                        {
                            end = true;
                            i = current_size - 1;
                            current_size *= 2;
                            break;
                        }
                    }
                    if (!end)
                    {
                        int len = marks.Length;
                        sum = 0;
                        count = count + current_size / 2;
                        for (int j = len - count; j < len; j++)
                        {
                            sum += marks[j];
                        }
                        temp_marks[temp_marks.Length - 1] = sum / count;
                        if (2 * (sum % count)/count == 1)
                        {
                            temp_marks[temp_marks.Length - 1]++;
                        }
                        break;
                    }
                    else
                    {
                        Array.Resize(ref temp_marks, temp_marks.Length + 1);
                        temp_marks[temp_marks.Length - 1] = sum / count;
                        if (2 * (sum % count)/count == 1)
                        {
                            temp_marks[temp_marks.Length - 1]++;
                        }
                    }
                }
                int summary = 0;
                int length = temp_marks.Length;
                for (int i = 0; i < length; i++)
                {
                    summary += temp_marks[i];
                }
                summary /= temp_marks.Length;
                if (2 * (summary % length)/length == 1)
                {
                    summary++;
                }
                Summary = summary;
            }
            else
            {
                Summary = 0;
            }
        }

        public void SetFriendsRate(int[][] friends_marks, string[] friends_login)
        {
            Friends = new List<MotionComplete>();
            for(int i=0; i<friends_login.Length; i++)
            {
                Friends.Add(
                    new MotionComplete(friends_marks[i], friends_login[i]));
            }
            Friends.OrderBy(x=>x.Summary);
            int place = 1;
            foreach(MotionComplete friend in Friends)
            {

                if(friend.Summary < this.Summary ||
                    (friend.Summary == this.Summary
                    && friend.Max <= this.Max))
                {
                        this.Place = place;
                        place++;
                }
                friend.Place = place;
                place++;
            }
        }
    }
}
