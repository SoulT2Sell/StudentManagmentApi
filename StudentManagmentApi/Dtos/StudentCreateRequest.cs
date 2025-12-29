namespace StudentManagmentApi.Dtos
{
    public class StudentCreateRequest
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public int? Age { get; set; }
        public List<StudentCoursesResponse> Courses { get; set; } = new();
    }
}
