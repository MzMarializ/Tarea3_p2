using Comprax.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comprax.Controllers
{
    public class ProductoController : Controller 
    {
        private readonly ContextoDatos _contexto;

        public ProductoController(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            var productos = _contexto.Productos;
            return View(productos);
        }

        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Id = _contexto.Productos.Count + 1;
                _contexto.Productos.Add(producto);
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        [HttpGet] 
        public IActionResult Edit(int id)
        {
            var producto = _contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost] 
        public IActionResult Edit(Producto producto)
        {
            var prod = _contexto.Productos.FirstOrDefault(p => p.Id == producto.Id);
            if (prod != null)
            {
                prod.Nombre = producto.Nombre;
                prod.Precio = producto.Precio;
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            var producto = _contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _contexto.Productos.Remove(producto);
            }
            return RedirectToAction("Index");
        }
    }
}
