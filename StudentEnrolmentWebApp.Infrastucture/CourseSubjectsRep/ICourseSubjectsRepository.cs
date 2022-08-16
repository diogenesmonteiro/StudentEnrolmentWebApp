using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Infrastructure.CourseSubjectsRep
{
    public interface ICourseSubjectsRepository
    {
        Task<IEnumerable<CourseSubject>> GetAll();

        Task<CourseSubject> GetById(int id);

        Task Add(CourseSubject newCourseSubject);

        Task Update(int id, CourseSubject newCourseSubject);

        Task Remove(int id);
    }
}
