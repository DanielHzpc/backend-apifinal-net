using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.DTOs
{
    public class ReservaServicioDto
    {
        [Required]
        public int ReservaId { get; set; }
        [Required]
        public int ServicioId { get; set; }
    }
}
