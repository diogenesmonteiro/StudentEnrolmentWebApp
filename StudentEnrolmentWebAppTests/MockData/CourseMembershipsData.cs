using System.Collections.Generic;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Tests.MockData
{
    class CourseMembershipsData
    {
        public static IEnumerable<CourseMembership> CourseMembershipsList()
        {
            var courseMemberships = new List<CourseMembership>
            {
                new CourseMembership(){ Id = 1, StudentId = 5, CourseId = 2 },
                new CourseMembership(){ Id = 2, StudentId = 25, CourseId = 3 },
                new CourseMembership(){ Id = 3, StudentId = 49, CourseId = 4 }
            };
            return courseMemberships;
        }

        public static CourseMembership OneCourseMembership()
        {
            var courseMembership = new CourseMembership() { Id = 1, StudentId = 5, CourseId = 2 };
            return courseMembership;
        }
    }
}

