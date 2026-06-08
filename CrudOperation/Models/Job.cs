using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        public int RecruiterId { get; set; }//FK

        public string JobTitle { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string Qualification { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Experience { get; set; } = null!;

        public decimal Salary { get; set; }

        public string JobDescription { get; set; } = null!;

        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}
