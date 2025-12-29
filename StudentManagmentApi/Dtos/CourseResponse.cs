using StudentManagmentApi.Models;
using System.Text.Json.Serialization;

namespace StudentManagmentApi.Dtos
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Credit { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
