using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string StudentName { get; set; } = null!;

        public string Qualification { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Skills { get; set; } = null!;

    }
}
