namespace StudentManagmentApi.Dtos
{
    public class CourseStudentsResponse
    {
        public int Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public int? Age { get; set; }
    }
}
