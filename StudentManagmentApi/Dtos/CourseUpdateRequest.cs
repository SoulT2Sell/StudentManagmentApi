using StudentManagmentApi.Models;

namespace StudentManagmentApi.Dtos
{
    public class CourseUpdateRequest
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Credit { get; set; }

        public List<int> Students { get; set; } = new();
    }
}
