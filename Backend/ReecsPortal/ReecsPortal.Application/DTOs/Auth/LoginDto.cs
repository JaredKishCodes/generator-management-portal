

using System.ComponentModel.DataAnnotations;

namespace ReecsPortal.Application.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
