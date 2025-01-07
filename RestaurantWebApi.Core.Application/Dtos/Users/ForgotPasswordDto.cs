using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApi.Core.Application.Dtos.Users
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
