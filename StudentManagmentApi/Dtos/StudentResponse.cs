namespace StudentManagmentApi.Dtos
{
    public record StudentResponse(
        int Id,
        string Firstname,
        string Lastname,
        string Email,
        int? Age,
        List<StudentCoursesResponse>? Courses
    );
}
