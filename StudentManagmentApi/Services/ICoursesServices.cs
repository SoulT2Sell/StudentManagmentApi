using StudentManagmentApi.Dtos;

namespace StudentManagmentApi.Services
{
    public interface ICoursesServices
    {
        Task<CourseResponse> CreateNewCourseAsync(CourseCreateRequest course);
        Task<bool> DeleteCourseAsyce(int id);
        Task<List<CourseResponse>> GetAllCoursesAsync();
        Task<CourseResponse> GetCourseByIdAsync(int id);
        Task<int> UpdateCourseAsync(int id, CourseUpdateRequest newCourse);
    }
}