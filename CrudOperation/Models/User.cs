using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is Required.")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; } = null!;
    }
}
