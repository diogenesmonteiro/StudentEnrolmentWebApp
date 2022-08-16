using System.Collections.Generic;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Tests.MockData
{
    public static class CoursesData
    {
        public static IEnumerable<Course> CoursesList()
        {
            var courses = new List<Course>
            {
                new Course(){ Id = 1, Name = "Anthropology Degree", Description = "Anthropology is...", IsPartFunded = true},
                new Course(){ Id = 2, Name = "Physiotherapy Degree", Description = "Physiotherapy is...", IsPartFunded = false},
                new Course(){ Id = 3, Name = "Computer Science Degree", Description = "A computer science degree is...", IsPartFunded = true}
            };
            return courses;
        }

        public static Course OneCourse()
        {
            var course = new Course() {Id = 1, Name = "Computer Science Degree", Description = "A computer science degree is...", IsPartFunded = true};
            return course;
        }
    }
}
