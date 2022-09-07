using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.Data;

namespace StudentEnrolmentWebApp.Infrastructure.CourseSubjectsRep
{
    public class CourseSubjectsRepository : ICourseSubjectsRepository
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public CourseSubjectsRepository(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CourseSubject>> GetAll()
        {
            return await Task.FromResult<IEnumerable<CourseSubject>>(_dbContext.CourseSubjects.ToList<CourseSubject>());
        }

        public async Task<CourseSubject> GetById(int id)
        {
            return await Task.FromResult<CourseSubject>(_dbContext.CourseSubjects.Find(id));
        }

        public async Task Add(CourseSubject newCourseSubject)
        {
            _dbContext.CourseSubjects.Add(newCourseSubject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, CourseSubject newCourseSubject)
        {
            var courseSubject = await _dbContext.CourseSubjects.FindAsync(id);

            courseSubject.CourseId = newCourseSubject.CourseId;
            courseSubject.SubjectId = newCourseSubject.SubjectId;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var courseSubject = await _dbContext.CourseSubjects.FindAsync(id);
            _dbContext.CourseSubjects.Remove(courseSubject);
            await _dbContext.SaveChangesAsync();
        }
    }
}
