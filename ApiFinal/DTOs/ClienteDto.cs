using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.DTOs
{
    public class ClienteDto
    {
        [Required(ErrorMessage="El nombre es obligatorio")]
        public string Nombre { get; set; } = "";
        [Required]
        public string Telefono { get; set; } = "";
        [Required]
        public bool Estado { get; set; }
    }
}
