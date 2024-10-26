using Comprax.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comprax.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly ContextoDatos _contexto;

        public ProveedorController(ContextoDatos contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var proveedores = _contexto.Proveedores;
            return View(proveedores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                proveedor.Id = _contexto.Proveedores.Count + 1;
                _contexto.Proveedores.Add(proveedor);
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        public IActionResult Edit(int id)
        {
            var proveedor = _contexto.Proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Edit(Proveedor proveedor)
        {
            var prov = _contexto.Proveedores.FirstOrDefault(p => p.Id == proveedor.Id);
            if (prov != null)
            {
                prov.Nombre = proveedor.Nombre;
                prov.Direccion = proveedor.Direccion;
                prov.Telefono = proveedor.Telefono;
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        public IActionResult Delete(int id)
        {
            var proveedor = _contexto.Proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor != null)
            {
                _contexto.Proveedores.Remove(proveedor);
            }
            return RedirectToAction("Index");
        }
    }
}
