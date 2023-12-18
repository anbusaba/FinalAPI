using System.ComponentModel.DataAnnotations;

namespace SmartMonitoringSystem.Core.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in proper email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; } = string.Empty;


    }
}
