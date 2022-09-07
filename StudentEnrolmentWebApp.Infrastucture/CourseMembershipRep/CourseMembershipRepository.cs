using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.Data;

namespace StudentEnrolmentWebApp.Infrastructure.CourseMembershipRep
{
    public class CourseMembershipRepository : ICourseMembershipRepository
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public CourseMembershipRepository(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CourseMembership>> GetAll()
        {
            return await Task.FromResult<IEnumerable<CourseMembership>>(_dbContext.CourseMemberships.ToList<CourseMembership>());
        }

        public async Task<CourseMembership> GetById(int id)
        {
            return await Task.FromResult<CourseMembership>(_dbContext.CourseMemberships.Find(id));
        }

        public async Task Add(CourseMembership newCourseMembership)
        {
            _dbContext.CourseMemberships.Add(newCourseMembership);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, CourseMembership newCourseMembership)
        {
            var courseMembership = await _dbContext.CourseMemberships.FindAsync(id);

            courseMembership.StudentId = newCourseMembership.StudentId;
            courseMembership.CourseId = newCourseMembership.CourseId;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var courseMembership = await _dbContext.CourseMemberships.FindAsync(id);
            _dbContext.CourseMemberships.Remove(courseMembership);
            await _dbContext.SaveChangesAsync();
        }
    }
}
