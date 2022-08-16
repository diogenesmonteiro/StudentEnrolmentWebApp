using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Services.CourseMembershipsServices
{
    public interface ICourseMembershipsService
    {
        Task<IEnumerable<CourseMembership>> GetAll();

        Task<CourseMembership> GetById(int id);

        Task Add(CourseMembership newCourseMembership);

        Task Update(int id, CourseMembership newCourseMembership);

        Task Remove(int id);
    }
}
