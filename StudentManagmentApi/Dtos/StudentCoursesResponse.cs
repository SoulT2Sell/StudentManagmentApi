using StudentManagmentApi.Models;

namespace StudentManagmentApi.Dtos
{
    public class StudentCoursesResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Credit { get; set; }
    }
}
