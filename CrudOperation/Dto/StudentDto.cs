using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string Qualifiaction { get; set; } = null!;

        public string Language { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
