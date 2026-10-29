namespace Gestion_Productos.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Activo { get; set; }

       
        public Producto() { }

        
        public Producto(int id, string nombre, decimal precio, string categoria, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
            Activo = activo;
        }
    }
}