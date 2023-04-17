using System.Net;
using Newtonsoft.Json;
using Programando.CSharp.ConsoleEF.Model;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using System.Text;
using System.Net.Http.Headers;

namespace Programando.CSharp.ConsoleHttpClient
{
    internal class Program
    {

        private static HttpClient _httpClient;

        class CPostal
        {
            [JsonProperty("post code")]
            [JsonPropertyName("post code")]
            public string Post_code { get; set; }
            public string Country { get; set; }
            [JsonProperty("country abbreviation")]
            [JsonPropertyName("country abbreviation")]
            public string Country_abbreviation { get; set; }
            public List<Dictionary<string, string>> Places { get; set; }

        }


        static void Main(string[] args)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5117/api/");
            //_httpClient.BaseAddress = new Uri("https://api.zippopotam.us/");
            Eco2();

        }

        static void Eco() 
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://postman-echo.com/");

            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Add("X-Param-1", "Demo");
            http.DefaultRequestHeaders.Add("X-Param-2", "Demo");
            http.DefaultRequestHeaders.Add("User-Agent", "HttpClient .NET Core");

            http.DefaultRequestHeaders.Add("Accept", "application/json");
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var obj = new { Nombre = "Borja Cabeza", Country = "Spain" };
            var body = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = http.PostAsync("post?p1=demo&p2=demo2", body).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
               var data = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(data);
            }
            else Console.WriteLine($"Error: {response.StatusCode}");

        }

        static void Eco2()
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://postman-echo.com/");

            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Add("User-Agent", "HttpClient .NET Core");
            http.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "post?p1=demo&p2=demo2");
            request.Headers.Add("X-Param-10", "Demo 10");
            request.Headers.Add("X-Param-20", "Demo 20");

            var obj = new { Nombre = "Borja Cabeza", Country = "Spain" };
            var body = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = http.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(data);
            }
            else Console.WriteLine($"Error: {response.StatusCode}");

        }

        static void GetCustomers()
        {
            Console.Clear();
            Console.WriteLine("ID Cliente: ");
            var id = Console.ReadLine();

            // Realizamos una llamada Get al microservicio y obtenemos la respuesta
            var response = _httpClient.GetAsync($"customers/{id}").Result;

            // Analizamos el código HTTP de respuesta

            // IsSuccessStatusCode es TRUE si la llamada retorna un código de estado entre 200 y 299
            if (response.IsSuccessStatusCode)
            {

            }


            // Buscamos que la respuesta sea HttpStatusCode.OK equivalente a 200
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Recuperamos el contenido del cuerpo del mensaje en formato JSON
                var data = response.Content.ReadAsStringAsync().Result;


                // <Convertimos el Json en un Objeto
                Customer cliente = JsonConvert.DeserializeObject<Customer>(data);

                Console.WriteLine($"Cliente: {cliente.CompanyName} - {cliente.Country}");
            }
            else Console.WriteLine(response.StatusCode.ToString());
        }

        static void GetCustomers4()
        {
            Console.Clear();
            Console.WriteLine("ID Cliente: ");
            var id = Console.ReadLine();

            Customer cliente = _httpClient.GetFromJsonAsync<Customer>($"customers/{id}").Result;
            if (cliente != null)
            {
                Console.WriteLine($"Cliente: {cliente.CompanyName} - {cliente.Country}");
            }
            else { Console.WriteLine("Cliente no encontrado"); }
        }

        static void PostalCode()
        {
            Console.Clear();
            Console.WriteLine("Postal Code: ");
            string cp = Console.ReadLine();

            var info = _httpClient.GetFromJsonAsync<CPostal>($"es/{cp}").Result;
            if (info != null)
            {
                Console.WriteLine($"Country: {info.Country}");
                Console.WriteLine($"Country_abbreviation: {info.Country_abbreviation}");
                foreach (var item in info.Places)
                {
                    Console.WriteLine($"{item} -¨{item["state"]}");
                }
            }
            else { Console.WriteLine("Cliente no encontrado"); }
        }

        static void PostCustomer() 
        {
            Console.Clear();
            Console.Write("ID: ");
            string id = Console.ReadLine();
            var cliente = new Customer()
            {
                CustomerID = id,
                CompanyName= "Empresa DD001, SL",
                ContactName= "Borja Cabeza",
                City= "Madrid",
                Country = "Spain"
            };

            string clienteJSON = JsonConvert.SerializeObject( cliente );

            StringContent contenido = new StringContent( clienteJSON, Encoding.UTF8, "application/json" );

            HttpResponseMessage response = _httpClient.PostAsync("customers", contenido).Result;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                Customer data = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine($"Company Name: {data.CompanyName}");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void PutCustomer()
        {
            Console.Clear();
            Console.Write("ID: ");
            string id = Console.ReadLine();
            var cliente = _httpClient.GetFromJsonAsync<Customer>($"customers/{id}").Result;
            
            cliente.ContactName = "Ana Trujillo";
            cliente.Phone = "600 993 166";


            string clienteJSON = JsonConvert.SerializeObject(cliente);
            StringContent contenido = new StringContent(clienteJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PutAsync($"customers/{id}", contenido).Result;
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                Console.WriteLine($"CLiente: {id} modificado");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void DeleteCustomer()
        {
            Console.Clear();
            Console.Write("ID: ");
            string id = Console.ReadLine();

            HttpResponseMessage response = _httpClient.DeleteAsync($"customers/{id}").Result;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                Console.WriteLine($"CLiente: {id} eliminado");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void GetCustomersEMT()
        {

        }
    }
}