using Aplicación1.Models;
using Newtonsoft.Json;
using System.Text;

namespace Aplicación1.Services
{
    public class APIService : MyApiService
    {

        private static string _baseUrl;

        public APIService() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;
           
        } 
        public async Task<string> DeleteProducto(int IdProdcuto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response =  await httpClient.DeleteAsync("api/Producto/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                
                return "Producto eliminado con éxito.";
            }
            else
            {
                
                throw new Exception($"Error al eliminar el producto: {response.StatusCode}");
            }
        }

        public async Task<Producto> GetProducto(int IdProducto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync($"api/Producto/{IdProducto}");
            var json_response = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            else
            {
                throw new Exception($"Error al obtener el producto: {response.StatusCode}");
            }
        }
        

        public async Task<List<Producto>> GetProductos()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri( _baseUrl );
            var response = await httpClient.GetAsync( "api/Producto/");
            var json_response  = await response.Content.ReadAsStringAsync();
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
            return productos;

        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var jsonBody = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonBody, Encoding.UTF8, "Aplicación1/json");
            var response = await httpClient.PostAsync("api/Producto/{IdProducto}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto nuevoProducto = JsonConvert.DeserializeObject<Producto>(json_response);
                return nuevoProducto;
            }
            else
            {
                
                throw new Exception($"Error al crear el producto: {response.StatusCode}");
            }
        }

        public async Task<Producto> PutProducto(int IdProducto, Producto producto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var jsonBody = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/Producto/{IdProducto}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto productoActualizado = JsonConvert.DeserializeObject<Producto>(json_response);
                return productoActualizado;
            }
            else
            {
                
                throw new Exception($"Error al actualizar el producto: {response.StatusCode}");
            }
        }
    }
}
