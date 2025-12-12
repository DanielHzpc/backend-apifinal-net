using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";

        [Required]
        public string Rol { get; set; } = "";
    }
}
