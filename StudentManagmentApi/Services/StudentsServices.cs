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
                .Select(s => new StudentResponse(
                        s.Id,
                        s.Firstname,
                        s.Lastname,
                        s.Email,
                        s.Age,
                        s.Courses.Select(c => new StudentCoursesResponse(
                                c.Id,
                                c.Title,
                                c.Credit
                            )
                        
                        ).ToList()
                    )
                )
                .ToListAsync();
        public async Task<StudentResponse> GetStudentByIdAsync(int id)
        {
            var student = await context.Students
                .Where(s => s.Id == id)
                .Select(s => new StudentResponse(
                        s.Id,
                        s.Firstname,
                        s.Lastname,
                        s.Email,
                        s.Age,
                        s.Courses.Select(c => new StudentCoursesResponse(
                                c.Id,
                                c.Title,
                                c.Credit
                            )
                        ).ToList()
                    )
                ).FirstOrDefaultAsync();

            return student;
        }
        public async Task<StudentResponse> CreateNewStudentAsync(StudentCreateRequest student)
        {
            var newStudentCourses = await context.Courses
                .Where(c => student.CoursesId.Contains(c.Id))
                .ToListAsync();

            if (newStudentCourses.Count < student.CoursesId.Count)
                return null;

            var newStudent = new Student
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Email = student.Email,
                Age = student.Age,
                Courses = newStudentCourses
            };

            context.Students.Add(newStudent);
            await context.SaveChangesAsync();

            return new StudentResponse(
                newStudent.Id,
                newStudent.Firstname,
                newStudent.Lastname,
                newStudent.Email,
                newStudent.Age,
                newStudent.Courses
                    .Select(c => new StudentCoursesResponse(
                            c.Id,
                            c.Title,
                            c.Credit
                        )   
                    ).ToList()
            );
        }
        public async Task<int> UpdateStudentAsync(int id, StudentUpdateRequest newStudent)
        {
            var student = await context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == id); 

            if(student == null) 
                return -1;

            var newCourses = await context.Courses
                .Where(c => newStudent.CoursesId.Contains(c.Id))
                .ToListAsync();

            if (newCourses.Count < newStudent.CoursesId.Count)
                return 0;

            student.Firstname = newStudent.Firstname;   
            student.Lastname = newStudent.Lastname; 
            student.Email = newStudent.Email;
            student.Age = newStudent.Age;
            student.Courses.Clear();
            student.Courses.AddRange(newCourses);

            await context.SaveChangesAsync();

            return 1;
        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
                return false;

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
