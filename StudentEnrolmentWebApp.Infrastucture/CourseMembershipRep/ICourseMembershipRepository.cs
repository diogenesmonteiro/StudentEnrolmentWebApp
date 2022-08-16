using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Infrastructure.CourseMembershipRep
{
    public interface ICourseMembershipRepository
    {
        Task<IEnumerable<CourseMembership>> GetAll();

        Task<CourseMembership> GetById(int id);

        Task Add(CourseMembership newStudent);

        Task Update(int id, CourseMembership newStudent);

        Task Remove(int id);
    }
}
