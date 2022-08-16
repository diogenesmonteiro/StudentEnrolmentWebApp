using System.Collections.Generic;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.CourseMembershipRep;

namespace StudentEnrolmentWebApp.Services.CourseMembershipsServices
{
    public class CourseMembershipsService : ICourseMembershipsService
    {
        private readonly ICourseMembershipRepository _courseMembershipRepository;

        public CourseMembershipsService(ICourseMembershipRepository courseMembershipRepository)
        {
            _courseMembershipRepository = courseMembershipRepository;
        }

        public async Task<IEnumerable<CourseMembership>> GetAll()
        {
            return await _courseMembershipRepository.GetAll();
        }

        public async Task<CourseMembership> GetById(int id)
        {
            return await _courseMembershipRepository.GetById(id);
        }

        public async Task Add(CourseMembership newCourseMembership)
        {
            await _courseMembershipRepository.Add(newCourseMembership);
        }

        public async Task Update(int id, CourseMembership newCourseMembership)
        {
            await _courseMembershipRepository.Update(id, newCourseMembership);
        }

        public async Task Remove(int id)
        {
            await _courseMembershipRepository.Remove(id);
        }
    }
}
