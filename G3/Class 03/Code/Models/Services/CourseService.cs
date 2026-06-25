using Models.Database;
using Models.Models.Domain;
using Models.Models.ViewModels;

namespace Models.Services
{
    public class CourseService
    {
        public List<CourseViewModel> GetCoursesWithMoreThanNineClasses()
        {
            //get the data from data access - StaticDb
            var courses = StaticDb.Courses.Where(x => x.NumberOfClasses > 9).ToList(); //here we have a List<Course>, we are working wit the domain model

            //we don't want to send the domain model to the controller, instead we want to only give it the data it needs
            List<CourseViewModel> result = new List<CourseViewModel>();

            foreach(Course course in courses)
            {
                result.Add(new CourseViewModel
                {
                    Name = course.Name,
                    NumberOfClasses = course.NumberOfClasses,
                }); //we map the domain model into the view model
            }

            return result;
        }
    }
} 
