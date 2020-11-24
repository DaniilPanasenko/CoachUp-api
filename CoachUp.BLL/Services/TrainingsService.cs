using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class TrainingsService
    {
        private UnitOfWork db;
        public TrainingsService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public void AddTraining(TrainingFromListDTO training, int course_id, string login)
        {
            Course course = db.Courses.Get(course_id);
            if (course != null && course.Coach_Login == login)
            {
                Training new_training = new Training()
                {
                    Name = training.Name,
                    Description = training.Description,
                    Course_ID = course_id,
                    Num_in_Course = course.Trainings.Count()
                };
                db.Trainings.Create(new_training);
                db.Save();
            }
        }

        public TrainingFromListDTO[] TrainingsList(int course_id)
        {
            Course course = db.Courses.Get(course_id);
            if (course != null)
            {
                return course.Trainings
                    .OrderBy(x => x.Num_in_Course)
                    .Select(x => new TrainingFromListDTO(x))
                    .ToArray();
            }
            return null;
        }

        public void ChangeTrainingsSequence(int[] sequence, string login)
        {
            bool todo = true;
            for(int i=0; i<sequence.Length; i++)
            {
                Training training = db.Trainings.Get(sequence[i]);
                if (training != null && training.Course.Coach_Login == login)
                {
                    training.Num_in_Course = i;
                    db.Trainings.Update(training);
                }
                else
                {
                    todo = false;
                }
            }
            if (todo)
            {
                db.Save();
            }
        }

        public TrainingDTO Info(int id)
        {
            Training training = db.Trainings.Get(id);
            if (training != null)
            {
                return new TrainingDTO(db.Trainings.Get(id));
            }
            return null;
        }

        public void DeleteTraining(int id, string login)
        {
            Training training = db.Trainings.Get(id);
            if (training != null && training.Course.Coach_Login==login)
            {
                int num = training.Num_in_Course;
                int course = training.Course_ID;
                db.Trainings.Delete(id);
                List<Training> trainings = db.Trainings
                    .Find(x => x.Course_ID == course && x.Num_in_Course > num)
                    .ToList();
                foreach (Training tr in trainings)
                {
                    tr.Num_in_Course--;
                    db.Trainings.Update(tr);
                }
                db.Save();
            }
        }

        public void EditTraining(TrainingDTO trainingDTO, string login)
        {
            Training training = db.Trainings.Get(trainingDTO.ID);
            if (training != null && training.Course.Coach_Login == login)
            {
                training.Name = trainingDTO.Name;
                training.Description = trainingDTO.Description;
                db.Trainings.Update(training);
                db.Save();
            }
        }

    }
}