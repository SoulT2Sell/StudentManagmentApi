using System.ComponentModel.DataAnnotations;
namespace StudentManagmentApi.Dtos
{
    public record CourseUpdateRequest(
            [Required]
            int Id,
            [Required, MinLength(1)]
            string Title,
            [Required]
            int Credit,
            List<int>? Students
        );
}
