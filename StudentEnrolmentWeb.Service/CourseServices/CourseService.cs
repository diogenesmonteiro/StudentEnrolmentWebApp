using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.CourseRep;
using StudentEnrolmentWebApp.Infrastructure.Data;

namespace StudentEnrolmentWebApp.Services.CourseServices
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<Course> GetById(int id)
        {
            return await _courseRepository.GetById(id);
        }

        public async Task Add(Course newCourse)
        {
            await _courseRepository.Add(newCourse);
        }

        public async Task Update(int id, Course newCourse)
        {
            await _courseRepository.Update(id, newCourse);
        }

        public async Task Remove(int id)
        {
            await _courseRepository.Remove(id);
        }
    }
}
