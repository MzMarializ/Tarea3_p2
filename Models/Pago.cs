namespace Comprax.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int OrdenCompraId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
