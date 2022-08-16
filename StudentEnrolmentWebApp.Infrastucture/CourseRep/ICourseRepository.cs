using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Infrastructure.CourseRep
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();

        Task<Course> GetById(int id);

        Task Add(Course newCourse);

        Task Update(int id, Course newCourse);

        Task Remove(int id);
    }
}
