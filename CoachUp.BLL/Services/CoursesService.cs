using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CoachUp.BLL.Services
{
    public class CoursesService
    {
        private UnitOfWork db;
        public CoursesService(ServiceModule sm)
        {
            db = sm.DB;
        }

        public List<MyCourseFromListDTO> GetCoursesByUserAndSport(string login, string sport)
        {
            Trainee trainee = db.Trainees.Get(login);
            List<Course> courses = trainee.Member_in_Courses
                .Select(x => x.Course)
                .Where(x => x.Coach.Sport.Name == sport)
                .ToList();
            return courses.ConvertAll(x => new MyCourseFromListDTO(x, trainee));
        }

    }
}
