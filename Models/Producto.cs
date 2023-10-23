namespace Aplicación1.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int cantidad { get; set; }

        public Producto() // Constructor sin parámetros requerido para model binding
        {

        }

        public Producto(int IdProducto, string Nombre, string Descripcion, int cantidad)
        {
            this.IdProducto = IdProducto;
            this.Nombre = Nombre;   
            this.Descripcion = Descripcion;
            this.cantidad = cantidad;
        }
    }
}
