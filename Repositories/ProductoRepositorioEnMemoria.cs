using Gestion_Productos.Models;

namespace Gestion_Productos.Repositories
{
    public class ProductoRepositorioEnMemoria : IProductoRepositorio
    {
        private readonly List<Producto> _productos;
        private int _ultimoId;

        public ProductoRepositorioEnMemoria()
        {
            _productos = new List<Producto>();
            _ultimoId = 3;
            _productos.Add(new Producto { Id = 1, Nombre = "Teclado", Precio = 15000m, Categoria = "Informatica", Activo = true });
            _productos.Add(new Producto { Id = 2, Nombre = "Mouse", Precio = 8000m, Categoria = "Informatica", Activo = true });
            _productos.Add(new Producto { Id = 3, Nombre = "Silla", Precio = 50000m, Categoria = "Muebles", Activo = true });
        }

        public List<Producto> ObtenerTodos() => _productos.ToList();

        public Producto? ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

        public Producto Agregar(Producto producto)
        {
            _ultimoId++;
            producto.Id = _ultimoId;
            _productos.Add(producto);
            return producto;
        }

        public bool Actualizar(Producto producto)
        {
            var existente = _productos.FirstOrDefault(p => p.Id == producto.Id);
            if (existente == null) return false;
            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Categoria = producto.Categoria;
            existente.Activo = producto.Activo;
            return true;
        }

        public bool Eliminar(int id)
        {
            var existente = _productos.FirstOrDefault(p => p.Id == id);
            if (existente == null) return false;
            _productos.Remove(existente);
            return true;
        }
    }
}