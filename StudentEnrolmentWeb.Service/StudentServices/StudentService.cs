using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.Data;
using StudentEnrolmentWebApp.Infrastructure.StudentRep;

namespace StudentEnrolmentWebApp.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _studentRepository.GetAll();
        }

        public async Task<Student> GetById(int id)
        {
            return await _studentRepository.GetById(id);
        }

        public async Task Add(Student newStudent)
        {
            await _studentRepository.Add(newStudent);
        }

        public async Task Update(int id, Student newStudent)
        {
            await _studentRepository.Update(id, newStudent);
        }

        public async Task Remove(int id)
        {
            await _studentRepository.Remove(id);
        }
    }
}
