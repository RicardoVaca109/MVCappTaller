using Aplicación1.Models;

namespace Aplicación1.Services
{
    public interface MyApiService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProducto(int IdProducto);
        Task<Producto> PostProducto(Producto producto);
        Task<Producto> PutProducto(int IdProducto, Producto producto);
        Task<string> DeleteProducto(int IdProducto);

    }
}
