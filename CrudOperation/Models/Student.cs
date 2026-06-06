using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Student Name is Required.")]
        public string StudentName { get; set; } = null!;

        [Required(ErrorMessage = "Gender is Required.")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "Date Of Birth is Required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } 

        [Required(ErrorMessage = "Age is Required.")]
        [Range(19,120,ErrorMessage ="Age Must Be Greater Than 18.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Qualifiaction is Required.")]
        public string Qualifiaction { get; set; } = null!;

        [Required(ErrorMessage = "Language is Required.")]
        public string Language { get; set; } = null!;

        [Required(ErrorMessage = "Location is Required.")]
        public string Location { get; set; } = null!;

    }
}
