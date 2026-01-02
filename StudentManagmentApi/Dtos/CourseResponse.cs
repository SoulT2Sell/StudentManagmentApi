namespace StudentManagmentApi.Dtos
{
    public record CourseResponse(
            int Id,
            string Title,
            int Credit,
            List<CourseStudentsResponse>? Students
        );
}
