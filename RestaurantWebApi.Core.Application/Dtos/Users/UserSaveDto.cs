using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApi.Core.Application.Dtos.Users
{
    public class UserSaveDto
    {
        [Required(ErrorMessage = "First name is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
