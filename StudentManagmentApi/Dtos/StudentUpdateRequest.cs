using System.ComponentModel.DataAnnotations;
namespace StudentManagmentApi.Dtos
{
    public record StudentUpdateRequest(

        [Required]
        int Id,
        [Required, MinLength(1)]
        string Firstname,
        [Required, MinLength(1)]
        string Lastname,
        [Required, EmailAddress]
        string Email,
        int? Age,
        List<int>? CoursesId

    );

}
