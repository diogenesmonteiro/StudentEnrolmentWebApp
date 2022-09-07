using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.CourseSubjectsServices;

namespace StudentEnrolmentWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectsController : ControllerBase
    {
        private readonly ICourseSubjectsService _courseSubjectsService;

        public CourseSubjectsController(ICourseSubjectsService courseSubjectsService)
        {
            _courseSubjectsService = courseSubjectsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _courseSubjectsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var courseSubject = await _courseSubjectsService.GetById(id);
            if (courseSubject == null)
                return NotFound("No record found with provided ID");

            return Ok(courseSubject);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseSubject newCourseSubject)
        {
            Task<IEnumerable<CourseSubject>> courseSubjects = _courseSubjectsService.GetAll();
            var lastCourseSubjectId = courseSubjects.Result.Last().Id;

            newCourseSubject.Id = lastCourseSubjectId + 1;

            await _courseSubjectsService.Add(newCourseSubject);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseSubject newCourseSubject)
        {
            await _courseSubjectsService.Update(id, newCourseSubject);
            return Ok(newCourseSubject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseSubjectsService.Remove(id);
            return Ok();
        }
    }
}
