using Gestion_Productos.Models;

namespace Gestion_Productos.Repositories
{
    public interface IProductoRepositorio
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
        Producto Agregar(Producto producto);
        bool Actualizar(Producto producto);
        bool Eliminar(int id);
    }
}