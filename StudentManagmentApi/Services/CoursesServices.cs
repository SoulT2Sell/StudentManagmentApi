using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudentManagmentApi.Data;
using StudentManagmentApi.Dtos;
using StudentManagmentApi.Models;

namespace StudentManagmentApi.Services
{
    public class CoursesServices(AppDbContext context) : ICoursesServices
    {
        public async Task<List<CourseResponse>> GetAllCoursesAsync()
            => await context.Courses
                .Select(c => new CourseResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    Credit = c.Credit,
                    Students = c.Students.Select(s => new CourseStudentsResponse
                    {
                        Id = s.Id,
                        Firstname = s.Firstname,
                        Lastname = s.Lastname,
                        Email = s.Email,
                        Age = s.Age,
                    }).ToList()
                })
                .ToListAsync();
        public async Task<CourseResponse> GetCourseByIdAsync(int id)
        {
            var course = await context.Courses
                .Select(c => new CourseResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    Credit = c.Credit,
                    Students = c.Students.Select(s => new CourseStudentsResponse
                    {
                        Id = s.Id,
                        Firstname = s.Firstname,
                        Lastname = s.Lastname,
                        Email = s.Email,
                        Age = s.Age,
                    }).ToList()
                })
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            return course;
        }
        public async Task<CourseResponse> CreateNewCourseAsync(CourseCreateRequest course)
        {
            var newCourseStudents = await context.Students
                .Where(s => course.Students.Contains(s.Id))
                .ToListAsync();

            if (newCourseStudents.Count < course.Students.Count)
                return null;

            var newCourse = new Course
            {
                Title = course.Title,
                Credit = course.Credit,
                Students = newCourseStudents
            };

            context.Courses.Add(newCourse); 
            await context.SaveChangesAsync();

            var courseResponse = new CourseResponse
            {
                Title = newCourse.Title,
                Credit = newCourse.Credit,
                Students = newCourse.Students
                    .Select(s => new CourseStudentsResponse
                    {
                        Id = s.Id,
                        Firstname = s.Firstname,
                        Lastname = s.Lastname,
                        Email = s.Email,
                        Age = s.Age,
                    }).ToList()
            };

            return courseResponse;
        }
        public async Task<int> UpdateCourseAsync(int id, CourseUpdateRequest newCourse)
        {
            var course = await context.Courses
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
                return -1;

            var newCourseStudents = await context.Students
                .Where(s => newCourse.Students.Contains(s.Id))
                .ToListAsync();

            if (newCourseStudents.Count < newCourse.Students.Count)
                return 0;

            course.Title = newCourse.Title;
            course.Credit = newCourse.Credit;
            course.Students.Clear();
            course.Students.AddRange(newCourseStudents);

            await context.SaveChangesAsync();

            return 1;
        }
        public async Task<bool> DeleteCourseAsyce(int id)
        {
            var course = await context.Courses
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
                return false;

            context.Courses.Remove(course);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
