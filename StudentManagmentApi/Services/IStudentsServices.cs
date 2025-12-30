using StudentManagmentApi.Dtos;

namespace StudentManagmentApi.Services
{
    public interface IStudentsServices
    {
        Task<List<StudentResponse>> GetAllStudentsAsync();
        Task<StudentResponse> GetStudentByIdAsync(int id);
        Task<StudentResponse> CreateNewStudentAsync(StudentCreateRequest newstudent);
        Task<int> UpdateStudentAsync(int id, StudentUpdateRequest newStudent);
        Task<bool> DeleteStudentAsync(int id);
    }
}