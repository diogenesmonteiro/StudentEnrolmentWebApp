using System.Collections.Generic;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Tests.MockData
{
    class CourseSubjectsData
    {
        public static IEnumerable<CourseSubject> CourseSubjectsList()
        {
            var courseSubjects = new List<CourseSubject>
            {
                new CourseSubject(){ Id = 1, CourseId = 2, SubjectId = 7},
                new CourseSubject(){ Id = 2, CourseId = 3, SubjectId = 10},
                new CourseSubject(){ Id = 3, CourseId = 4, SubjectId = 14}
            };
            return courseSubjects;
        }

        public static CourseSubject OneCourseSubject()
        {
            var courseSubject = new CourseSubject() { Id = 1, CourseId = 2, SubjectId = 7 };
            return courseSubject;
        }
    }
}
