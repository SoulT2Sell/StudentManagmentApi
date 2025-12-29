using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagmentApi.Dtos;
using StudentManagmentApi.Services;

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
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }
    }
}
