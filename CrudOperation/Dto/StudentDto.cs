using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        public string StudentName { get; set; } = null!;

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "Date Of Birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Qualification is required.")]
        public string Qualifiaction { get; set; } = null!;

        [Required(ErrorMessage = "Language is required.")]
        public string Language { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; } = null!;
    }
}
