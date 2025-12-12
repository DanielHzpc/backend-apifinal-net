namespace ApiEmpresa.Models
{
    public class ReservaServicio
    {
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
