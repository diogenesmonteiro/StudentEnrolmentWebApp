using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.CourseMembershipsServices;


namespace StudentEnrolmentWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseMembershipsController : ControllerBase
    {
        private readonly ICourseMembershipsService _courseMembershipsService;

        public CourseMembershipsController(ICourseMembershipsService courseMembershipsService)
        {
            _courseMembershipsService = courseMembershipsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _courseMembershipsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var courseMembership = await _courseMembershipsService.GetById(id);
            if (courseMembership == null)
                return NotFound("No record found with provided ID");

            return Ok(courseMembership);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseMembership newCourseMembership)
        {
            await _courseMembershipsService.Add(newCourseMembership);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseMembership newCourseMembership)
        {
            await _courseMembershipsService.Update(id, newCourseMembership);
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseMembershipsService.Remove(id);
            return Ok("Record deleted successfully");
        }
    }
}
