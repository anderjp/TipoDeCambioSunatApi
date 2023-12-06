using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Obtener la fecha actual en el formato necesario (por ejemplo, "yyyy-MM-dd")
        string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");

        // Inicializar cliente HTTP
        using (HttpClient client = new HttpClient())
        {
            // Configurar la URL de la API con la fecha actual (versión 1)
            string apiUrl = $"https://api.apis.net.pe/v1/tipo-cambio-sunat?fecha={fechaActual}";

            try
            {
                // Realizar la solicitud GET
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Verificar si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Leer y mostrar la respuesta
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    // Mostrar el código de estado en caso de error
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}


