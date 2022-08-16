using System.Collections.Generic;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Tests.MockData
{
    class SubjectsData
    {
        public static IEnumerable<Subject> SubjectsList()
        {
            var subjects = new List<Subject>
            {
                new Subject(){ Id = 1, Name = "Law and Resistance", Description = "This course will explore..." },
                new Subject(){ Id = 2, Name = "Chemistry", Description = "The course builds on the ideas..." },
                new Subject(){ Id = 3, Name = "Astrophysics", Description = "There are eight 24-lecture courses..." }
            };
            return subjects;
        }

        public static Subject OneSubject()
        {
            var subject = new Subject() { Id = 1, Name = "Law and Resistance", Description = "This course will explore..." };
            return subject;
        }
    }
}
