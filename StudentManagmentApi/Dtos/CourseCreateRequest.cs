using System.ComponentModel.DataAnnotations;
namespace StudentManagmentApi.Dtos
{
    public record CourseCreateRequest(
            [Required, MinLength(1)]
            string Title,
            [Required]
            int Credit,
            List<int>? Students
        );
}
