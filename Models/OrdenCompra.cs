namespace Comprax.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaOrden { get; set; }
        public bool Entregada { get; set; }
    }
}
