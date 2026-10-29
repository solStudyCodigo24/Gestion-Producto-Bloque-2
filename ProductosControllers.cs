using Gestion_Productos.DTOs;
using Gestion_Productos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Productos.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoServicio _servicio;

        public ProductosController(IProductoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(_servicio.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var producto = _servicio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearProductoDto nuevoProducto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var producto = _servicio.Crear(nuevoProducto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] CrearProductoDto productoDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_servicio.Actualizar(id, productoDto)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            if (!_servicio.Eliminar(id)) return NotFound();
            return NoContent();
        }
    }
}