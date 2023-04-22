using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.IntegrationTests.Helpers
{
    public class TestHelper
    {
        /// <summary>
        /// Método para conectar no servidor da API (Client)
        /// </summary>
        public static HttpClient CreateClient
            => new WebApplicationFactory<Program>().CreateClient();

        /// <summary>
        /// Serializar um objeto em JSON e enviar para um serviço
        /// </summary>
        public static StringContent CreateContent<T>(T command)
            => new StringContent(JsonConvert.SerializeObject(command), 
                Encoding.UTF8, "application/json");

        /// <summary>
        /// Deserializar um conteúdo JSON obtido da API
        /// </summary>
        public static T? ReadContent<T>(HttpResponseMessage message)
            => JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().Result);
    }
}
