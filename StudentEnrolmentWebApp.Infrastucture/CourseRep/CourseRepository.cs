using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.Data;

namespace StudentEnrolmentWebApp.Infrastructure.CourseRep
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public CourseRepository(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Course>> GetAll() =>
            Task.FromResult<IEnumerable<Course>>(_dbContext.Courses.ToList<Course>());

        public Task<Course> GetById(int id)
        {
            return Task.FromResult<Course>(_dbContext.Courses.Find(id));
        }

        public async Task Add(Course newCourse)
        {
            _dbContext.Courses.Add(newCourse);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, Course newCourse)
        {
            var course = await _dbContext.Courses.FindAsync(id);

            course.Name = newCourse.Name;
            course.Description = newCourse.Description;
            course.IsPartFunded = newCourse.IsPartFunded;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
        }
    }
}
