using Gestion_Productos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_Productos.Repositories
{
    public class ProductoRepository : IProductoRepositorio
    {
        private readonly List<Producto> _productos;

        public ProductoRepository()
        {
            _productos = new List<Producto>
            {
                new Producto(1, "Teclado", 15000m, "Informatica", true),
                new Producto(2, "Mouse", 8000m, "Informatica", true),
                new Producto(3, "Silla", 50000m, "Muebles", true),
                new Producto(4, "Escritorio", 80000m, "Muebles", false)
            };
        }

        public Producto Agregar(Producto producto)
        {
            if (producto.Id == 0)
            {
                producto.Id = _productos.Count == 0
                    ? 1
                    : _productos.Max(p => p.Id) + 1;
            }

            _productos.Add(producto);
            return producto;
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(producto => producto.Id == id);
        }

        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return _productos
                .Where(producto => producto.Categoria == categoria)
                .ToList();
        }

        public bool Actualizar(Producto producto)
        {
            var productoExistente = ObtenerPorId(producto.Id);
            if (productoExistente == null) return false;

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Precio = producto.Precio;
            productoExistente.Categoria = producto.Categoria;
            productoExistente.Activo = producto.Activo;
            return true;
        }

        public bool Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            return producto != null && _productos.Remove(producto);
        }
    }
}