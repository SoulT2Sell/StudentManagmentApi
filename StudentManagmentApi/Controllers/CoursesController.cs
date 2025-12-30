using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagmentApi.Dtos;
using StudentManagmentApi.Services;

namespace StudentManagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICoursesServices services) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CourseResponse>>> GetAllCourses()
            => await services.GetAllCoursesAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponse>> GetCourseById(int id)
        {
            var course = await services.GetCourseByIdAsync(id);
            return course is null ? NotFound("Course by given id is not exist!") : Ok(course);  
        }

        [HttpPost]
        public async Task<ActionResult<CourseResponse>> CreateNewCourse(CourseCreateRequest course)
        {
            var createdCourse = await services.CreateNewCourseAsync(course);
            return createdCourse is null ? BadRequest("Given Student id does not exist!") : Ok(createdCourse);   
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseUpdateRequest newCourse)
        {
            var updated = await services.UpdateCourseAsync(id, newCourse);
            return updated == -1 ? NotFound("Course by given id is not exist!") : 
                updated == 0 ? BadRequest("Student id you given is not exist!") : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await services.DeleteCourseAsyce(id);
            return deleted ? NoContent() : NotFound("Course by given id is not exist!");
        }
    }
}
