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

        public void AddTraining(TrainingFromListDTO training, int course_id)
        {
            Course course = db.Courses.Get(course_id);
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

        public TrainingFromListDTO[] TrainingsList(int course_id)
        {
            Course course = db.Courses.Get(course_id);
            return course.Trainings
                .OrderBy(x => x.Num_in_Course)
                .Select(x => new TrainingFromListDTO(x))
                .ToArray();
        }

        public void ChangeTrainingsSequence(int[] sequence)
        {
            for(int i=0; i<sequence.Length; i++)
            {
                Training training = db.Trainings.Get(sequence[i]);
                training.Num_in_Course = i;
                db.Trainings.Update(training);
            }
            db.Save();
        }

        public TrainingDTO Info(int id)
        {
            return new TrainingDTO(db.Trainings.Get(id));
        }

        public void DeleteTraining(int id)
        {
            int num = db.Trainings.Get(id).Num_in_Course;
            int course = db.Trainings.Get(id).Course_ID;
            db.Trainings.Delete(id);
            List<Training> trainings = db.Trainings
                .Find(x => x.Course_ID == course && x.Num_in_Course > num)
                .ToList();
            foreach(Training tr in trainings)
            {
                tr.Num_in_Course--;
                db.Trainings.Update(tr);
            }
            db.Save();
        }

        public void EditTraining(TrainingDTO trainingDTO)
        {
            Training training = db.Trainings.Get(trainingDTO.ID);
            training.Name = trainingDTO.Name;
            training.Description = trainingDTO.Description;
            db.Trainings.Update(training);
            db.Save();
        }

    }
}