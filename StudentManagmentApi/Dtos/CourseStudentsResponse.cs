namespace StudentManagmentApi.Dtos
{
    public record CourseStudentsResponse(
            int Id,
            string Firstname,
            string Lastname,
            string Email,
            int? Age
        );
}
