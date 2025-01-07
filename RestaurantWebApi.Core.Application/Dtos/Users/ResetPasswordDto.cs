using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApi.Core.Application.Dtos.Users
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Token is required")]
        [DataType(DataType.Text)]
        public string Token { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
