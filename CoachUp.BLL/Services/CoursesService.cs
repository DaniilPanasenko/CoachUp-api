using CoachUp.BLL.BusinessModels;
using CoachUp.BLL.DataTransferObjects;
using CoachUp.BLL.Infrastructure;
using CoachUp.BLL.Infrastructure.Enums;
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

        public List<MyCourseFromListDTO> GetCoursesByUser(string login)
        {
            Trainee trainee = db.Trainees.Get(login);
            if (trainee != null)
            {
                List<Course> courses = trainee.Member_in_Courses
                    .Select(x => x.Course)
                    .ToList();
                return courses.ConvertAll(x => new MyCourseFromListDTO(x, trainee));
            }
            return null;
        }

        public List<MyCourseFromListDTO> GetCoursesByUserAndSport(string login, string sport)
        {
            Trainee trainee = db.Trainees.Get(login);
            if (trainee != null)
            {
                List<Course> courses = trainee.Member_in_Courses
                .Select(x => x.Course)
                .Where(x => x.Coach.Sport.Name == sport)
                .ToList();
                return courses.ConvertAll(x => new MyCourseFromListDTO(x, trainee));
            }
            return null;
        }

        public List<CoachCourseFromListDTO> GetCoursesByCoach(string login)
        {
            Coach coach = db.Coaches.Get(login);
            if (coach != null)
            {
                List<Course> courses = coach.Courses.ToList();
                List<CoachCourseFromListDTO> coursesDTO = courses
                    .ConvertAll(x => new CoachCourseFromListDTO(x));
                return coursesDTO;
            }
            return null;
        }

        public CourseDTO GetCourseByID(int id)
        {
            Course course = db.Courses.Get(id);
            if (course != null)
            {
                return new CourseDTO(db.Courses.Get(id));
            }
            return null;
        }

        public int AddCourse(CourseDTO courseDTO, string login)
        {
            Course course = new Course
            {
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                Coach_Login = login
            };
            db.Courses.Create(course);
            db.Save();
            return course.ID;
        }

        public void DeleteCourse(int id, string login)
        {
            Course course = db.Courses.Get(login);
            if (course != null && course.Coach_Login == login)
            {
                db.Courses.Delete(id);
                db.Save();
            }
        }

        public void EditCourse(CourseDTO courseDTO, string login)
        {
            Course course = db.Courses.Get(courseDTO.ID);
            if (course != null && course.Coach_Login == login)
            {
                course.Name = courseDTO.Name;
                course.Description = courseDTO.Description;
                db.Courses.Update(course);
                db.Save();
            }
        }

        public void EnterToCourse(string login, int id)
        {
            Course course = db.Courses.Get(id);
            Trainee trainee = db.Trainees.Get(login);
            Member member0 = db.Members
                .Find(x => x.Trainee_Login == login && x.Course_Id == id)
                .FirstOrDefault();
            if (course != null && trainee != null && member0 == null)
            {
                Member member = new Member();
                member.Course_Id = id;
                member.Trainee_Login = login;
                member.Rate = 0;
                db.Members.Create(member);
                db.Save();
            }
        }

        public void LeaveCourse(string login, int id)
        {
            Course course = db.Courses.Get(id);
            Trainee trainee = db.Trainees.Get(login);
            Member member = db.Members
                .Find(x => x.Trainee_Login == login && x.Course_Id == id)
                .FirstOrDefault();
            if (course != null && trainee != null && member != null)
            {
                db.Members.Delete(member.ID);
                db.Save();
            }
        }


        public object FindCourses(
            string sport,
            string name,
            string coach,
            int? rate_min,
            int? rate_max,
            int? members_min,
            int? members_max,
            int page,
            int page_size,
            SortCourses? sort,
            bool desc)
        {
            List<CourseDTO> courses = db.Courses
                .GetAll()
                .Select(x => new CourseDTO(x))
                .ToList();

            if (sport != null)
            {
                courses = courses.Where(x => x.Sport == sport).ToList();
            }
            if (name != null)
            {
                courses = courses
                    .Where(x =>x.Name.ToLower().Contains(name.ToLower()))
                    .ToList();
            }
            if (coach != null)
            {
                coach = coach.ToLower();
                courses = courses
                    .Where(x =>
                        x.CoachName.ToLower().Contains(coach) ||
                        x.CoachLogin.ToLower().Contains(coach) ||
                        x.CoachSurname.ToLower().Contains(coach))
                    .ToList();
            }
            if (members_min != null)
            {
                courses = courses
                    .Where(x => x.CourseMember >= members_min)
                    .ToList();
            }
            if (members_max != null)
            {
                courses = courses
                    .Where(x => x.CourseMember <= members_max)
                    .ToList();
            }
            switch (sort)
            {
                case SortCourses.None:
                    break;

                case SortCourses.Name:
                    if (!desc)
                    {
                        courses = courses
                            .OrderBy(x => x.Name)
                            .ToList();
                    }
                    else
                    {
                        courses = courses
                            .OrderByDescending(x => x.Name)
                            .ToList();
                    }
                    break;

                case SortCourses.Members:
                    if (!desc)
                    {
                        courses = courses
                            .OrderBy(x => x.CourseMember)
                            .ToList();
                    }
                    else
                    {
                        courses = courses
                            .OrderByDescending(x => x.CourseMember)
                            .ToList();
                    }
                    break;
            }
            int count = courses.Count();
            courses = courses
                .Skip((page - 1) * page_size)
                .Take(page_size)
                .ToList();
            return new
            {
                CountCourses = count,
                Courses = courses
            };
        }

        
    }
}
