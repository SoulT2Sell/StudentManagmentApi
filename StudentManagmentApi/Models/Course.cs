using System.Text.Json.Serialization;

namespace StudentManagmentApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Credit { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
