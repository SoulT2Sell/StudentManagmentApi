using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagmentApi.Dtos;
using StudentManagmentApi.Services;
using System.Runtime.CompilerServices;

namespace StudentManagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentsServices services) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<StudentResponse>> GetAllStudents()
            => Ok(await services.GetAllStudentsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponse>> GetStudentById(int id)
        {
            var student = await services.GetStudentByIdAsync(id);
            return student is null ? NotFound("Student with given id not found!") : Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> CreateNewStudent(StudentCreateRequest student)
        {
            var createdStudent = await services.CreateNewStudentAsync(student);
            return createdStudent is null ? BadRequest("Your given course id doesnt exist!") : CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateRequest student)
        {
            var updated = await services.UpdateStudentAsync(id, student);
            return updated == -1 ? NotFound("Student with given id doesnt exist!") :
                updated == 0 ? BadRequest("Your given course id doenst exist!") : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await services.DeleteStudentAsync(id);
            return deleted ? NoContent() : NotFound("Student with given id doesnt exists!");
        }
    }
}
