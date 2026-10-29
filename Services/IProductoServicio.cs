using Gestion_Productos.DTOs;

namespace Gestion_Productos.Services
{
    public interface IProductoServicio
    {
        List<ProductoDto> ObtenerTodos();
        ProductoDto? ObtenerPorId(int id);
        ProductoDto Crear(CrearProductoDto dto);
        bool Actualizar(int id, CrearProductoDto dto);
        bool Eliminar(int id);
    }
}