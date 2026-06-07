using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = null!;

        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(20, MinimumLength = 6,
        //    ErrorMessage = "Password must be between 6 and 20 characters")]
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;
    }
}
