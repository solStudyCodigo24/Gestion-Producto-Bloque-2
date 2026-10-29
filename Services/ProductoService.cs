using Gestion_Productos.DTOs;
using Gestion_Productos.Models;
using Gestion_Productos.Repositories;

namespace Gestion_Productos.Services
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _repositorio;

        public ProductoServicio(IProductoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<ProductoDto> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos().Select(p => MapearADto(p)).ToList();
        }

        public ProductoDto? ObtenerPorId(int id)
        {
            var producto = _repositorio.ObtenerPorId(id);
            return producto == null ? null : MapearADto(producto);
        }

        public ProductoDto Crear(CrearProductoDto dto)
        {
            var nuevaEntidad = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Categoria = dto.Categoria,
                Activo = dto.Activo
            };
            var guardado = _repositorio.Agregar(nuevaEntidad);
            return MapearADto(guardado);
        }

        public bool Actualizar(int id, CrearProductoDto dto)
        {
            var existente = _repositorio.ObtenerPorId(id);
            if (existente == null) return false;
            existente.Nombre = dto.Nombre;
            existente.Precio = dto.Precio;
            existente.Categoria = dto.Categoria;
            existente.Activo = dto.Activo;
            return _repositorio.Actualizar(existente);
        }

        public bool Eliminar(int id) => _repositorio.Eliminar(id);

        private ProductoDto MapearADto(Producto p)
        {
            return new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Categoria = p.Categoria,
                Activo = p.Activo
            };
        }
    }
}