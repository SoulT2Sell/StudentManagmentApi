using Microsoft.EntityFrameworkCore;
using StudentManagmentApi.Data;
using StudentManagmentApi.Dtos;
using StudentManagmentApi.Models;

namespace StudentManagmentApi.Services
{
    public class StudentsServices(AppDbContext context) : IStudentsServices
    {
        public async Task<List<StudentResponse>> GetAllStudentsAsync()
            => await context.Students
                .Select(s => new StudentResponse
                {
                    Id = s.Id,
                    Firstname = s.Firstname,
                    Lastname = s.Lastname,
                    Email = s.Email,
                    Age = s.Age,
                    Courses = s.Courses.Select(c => new StudentCoursesResponse
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Credit = c.Credit,
                    }).ToList()
                })
                .ToListAsync();
        public async Task<StudentResponse> GetStudentByIdAsync(int id)
        {
            var student = await context.Students
                .Where(s => s.Id == id)
                .Select(s => new StudentResponse
                {
                    Id = s.Id,
                    Firstname = s.Firstname,
                    Lastname = s.Lastname,
                    Email = s.Email,
                    Age = s.Age,
                    Courses = s.Courses.Select(c => new StudentCoursesResponse
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Credit = c.Credit,
                    }).ToList()
                }).FirstOrDefaultAsync();

            return student;
        }
        public async Task<StudentResponse> CreateNewStudentAsync(StudentCreateRequest student)
        {
            var newStudent = new Student
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Email = student.Email,
                Age = student.Age,
                Courses = student.Courses
                    .Select(c => new Course
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Credit = c.Credit,
                    }).ToList()
            };

            context.Students.Add(newStudent);
            await context.SaveChangesAsync();

            return new StudentResponse
            {
                Id = newStudent.Id,
                Firstname = newStudent.Firstname,
                Lastname = newStudent.Lastname,
                Email = newStudent.Email,
                Age = newStudent.Age,
                Courses = newStudent.Courses
                    .Select(c => new StudentCoursesResponse
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Credit = c.Credit,
                    }).ToList(),
            };
        }
        //public async Task<bool> UpdateStudentAsync(int id, StudentUpdateRequest newStudent)
        //{

        //}
    }
}
