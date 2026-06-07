using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        public int JobId { get; set; }

        public int StudentId { get; set; }

        public DateTime AppliedDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Applied";
    }
}