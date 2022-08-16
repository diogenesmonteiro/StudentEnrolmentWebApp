using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.CourseSubjectsRep;
using StudentEnrolmentWebApp.Infrastructure.Data;

namespace StudentEnrolmentWebApp.Services.CourseSubjectsServices
{
    public class CourseSubjectsService : ICourseSubjectsService
    {
        private readonly ICourseSubjectsRepository _courseSubjectsRepository;

        public CourseSubjectsService(ICourseSubjectsRepository courseSubjectsRepository)
        {
            _courseSubjectsRepository = courseSubjectsRepository;
        }

        public async Task<IEnumerable<CourseSubject>> GetAll()
        {
            return await _courseSubjectsRepository.GetAll();
        }

        public async Task<CourseSubject> GetById(int id)
        {
            return await _courseSubjectsRepository.GetById(id);
        }

        public async Task Add(CourseSubject newCourseSubject)
        {
            await _courseSubjectsRepository.Add(newCourseSubject);
        }

        public async Task Update(int id, CourseSubject newCourseSubject)
        {
            await _courseSubjectsRepository.Update(id, newCourseSubject);
        }

        public async Task Remove(int id)
        {
            await _courseSubjectsRepository.Remove(id);
        }
    }
}
