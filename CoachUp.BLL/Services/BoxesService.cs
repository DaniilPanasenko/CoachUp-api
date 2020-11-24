using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class BoxesService
    {
        private UnitOfWork db;
        public BoxesService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public BoxDTO[] BoxesList(int training_id)
        {
            Training training = db.Trainings.Get(training_id);
            if (training != null)
            {
                List<BoxDTO> boxes = db.Boxes
                    .Find(x => x.Training_ID == training_id)
                    .Select(x => new BoxDTO(x))
                    .OrderBy(x=>x.Num_in_Training)
                    .ToList();
                foreach(BoxDTO box in boxes)
                {
                    Media media = db.Medias
                        .Find(x => x.Box_ID == box.ID)
                        .FirstOrDefault();
                    if (media != null)
                    {
                        box.IsMedia = true;
                        box.Link = media.Link;
                    }
                }
                return boxes.ToArray();
            }
            return null;
        }

        public void ChangeBoxesSequence(int[] sequence, string login)
        {
            bool todo = true;
            for (int i = 0; i < sequence.Length; i++)
            {
                Box box = db.Boxes.Get(sequence[i]);
                if (box != null && box.Training.Course.Coach_Login == login)
                {
                    box.Num_in_Training = i;
                    db.Boxes.Update(box);
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


        public void AddBox(BoxDTO box, int training_id, string login)
        {
            Training training = db.Trainings.Get(training_id);
            if (training != null && training.Course.Coach_Login == login)
            {
                Box new_box = new Box()
                {
                    Name = box.Name,
                    Description = box.Text,
                    Training_ID = training_id,
                    Num_in_Training = training.Boxes.Count()
                };
                db.Boxes.Create(new_box);
                db.Save();
                if (box.IsMedia)
                {
                    Media media = new Media()
                    {
                        Link = box.Link,
                        Box_ID = new_box.ID
                    };
                    db.Medias.Create(media);
                }
                else
                {
                    db.Motions.Create(new Motion() { Box_ID = new_box.ID });
                }
                db.Save();
            }
        }

        public void DeleteBox(int id, string login)
        {
            Box box = db.Boxes.Get(id);
            if (box != null && box.Training.Course.Coach_Login == login)
            {
                int num = box.Num_in_Training;
                int training = box.Training_ID;
                db.Boxes.Delete(id);
                List<Box> boxes = db.Boxes
                    .Find(x => x.Training_ID == training && x.Num_in_Training > num)
                    .ToList();
                Media media = db.Medias.Find(x => x.Box_ID == id).FirstOrDefault();
                if (media != null)
                {
                    db.Medias.Delete(media.ID);
                }
                Motion motion = db.Motions.Find(x => x.Box_ID == id).FirstOrDefault();
                if (motion != null)
                {
                    db.Motions.Delete(motion.ID);
                }
                foreach (Box bx in boxes)
                {
                    bx.Num_in_Training--;
                    db.Boxes.Update(bx);
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