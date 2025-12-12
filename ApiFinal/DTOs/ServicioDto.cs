using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.DTOs
{
    public class ServicioDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
