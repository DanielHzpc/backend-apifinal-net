using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.DTOs
{
    public class ReservasDto
    {
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public DateTime FechaReserva { get; set; }
        [Required]
        public string Estado {  get; set; }
    }
}
