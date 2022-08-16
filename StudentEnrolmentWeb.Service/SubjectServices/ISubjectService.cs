using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Services.SubjectServices
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAll();

        Task<Subject> GetById(int id);

        Task Add(Subject newSubject);

        Task Update(int id, Subject newSubject);

        Task Remove(int id);
    }
}
