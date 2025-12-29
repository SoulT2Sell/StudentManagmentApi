namespace StudentManagmentApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }   
        public required string Email { get; set; }
        public int? Age { get; set; }

        public List<Course> Courses { get; set; } = new();
    }
}
