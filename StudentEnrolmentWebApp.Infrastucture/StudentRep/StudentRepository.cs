using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.Data;

namespace StudentEnrolmentWebApp.Infrastructure.StudentRep
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public StudentRepository(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Student>> GetAll() =>
            Task.FromResult<IEnumerable<Student>>(_dbContext.Students.ToList<Student>());

        public Task<Student> GetById(int id)
        {
            return Task.FromResult<Student>(_dbContext.Students.Find(id));
        }

        public async Task Add(Student newStudent)
        {
            _dbContext.Students.Add(newStudent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, Student newStudent)
        {
            var student = await _dbContext.Students.FindAsync(id);

            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}
