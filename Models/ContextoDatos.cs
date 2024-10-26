namespace Comprax.Models
{
    public class ContextoDatos
    {
        public List<Producto> Productos { get; set; } = new List<Producto>();
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
        public List<OrdenCompra> OrdenesCompra { get; set; } = new List<OrdenCompra>();
        public List<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
