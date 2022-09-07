using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.SubjectServices;

namespace StudentEnrolmentWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _subjectService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var subject = await _subjectService.GetById(id);
            if (subject == null)
                return NotFound("No record found with provided ID");

            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Subject newSubject)
        {
            await _subjectService.Add(newSubject);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Subject newSubject)
        {
            await _subjectService.Update(id, newSubject);
            return Ok(newSubject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subjectService.Remove(id);
            return Ok();
        }
    }
}
