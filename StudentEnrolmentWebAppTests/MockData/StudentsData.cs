using System.Collections.Generic;
using StudentEnrolmentWebApp.Domain.Models;
namespace StudentEnrolmentWebApp.Tests.MockData
{
    public static class StudentsData
    {
        public static IEnumerable<Student> StudentsList()
        {
            var students = new List<Student>
            {
                new Student(){ Id = 1, FirstName = "John", LastName = "Smith" },
                new Student(){ Id = 2, FirstName = "Mary", LastName = "Cook" },
                new Student(){ Id = 2, FirstName = "Mark", LastName = "Spenser" }
            };
            return students;
        }

        public static Student OneStudent()
        {
            var student = new Student() { Id = 1, FirstName = "John", LastName = "Smith" };
            return student;
        }
    }
}
