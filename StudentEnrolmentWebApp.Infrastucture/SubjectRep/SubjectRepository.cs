using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.Data;

namespace StudentEnrolmentWebApp.Infrastructure.SubjectRep
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public SubjectRepository(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Subject>> GetAll() =>
            Task.FromResult<IEnumerable<Subject>>(_dbContext.Subjects.ToList<Subject>());

        public Task<Subject> GetById(int id)
        {
            return Task.FromResult<Subject>(_dbContext.Subjects.Find(id));
        }

        public async Task Add(Subject newSubject)
        {
            _dbContext.Subjects.Add(newSubject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, Subject newSubject)
        {
            var subject = await _dbContext.Subjects.FindAsync(id);

            subject.Name = newSubject.Name;
            subject.Description = newSubject.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var subject = await _dbContext.Subjects.FindAsync(id);
            _dbContext.Subjects.Remove(subject);
            await _dbContext.SaveChangesAsync();
        }
    }
}
