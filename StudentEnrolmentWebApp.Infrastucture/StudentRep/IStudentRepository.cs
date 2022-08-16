using System.Collections.Generic;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;

namespace StudentEnrolmentWebApp.Infrastructure.StudentRep
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();

        Task<Student> GetById(int id);

        Task Add(Student newStudent);

        Task Update(int id, Student newStudent);

        Task Remove(int id);
    }
}
