namespace ApiEmpresa.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaReserva { get; set; } = DateTime.Now;
        public string Estado { get; set; }

        public ICollection<ReservaServicio> ReservaServicio { get; set; }


    }
}
