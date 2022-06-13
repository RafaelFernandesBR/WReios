using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RasReiios.DadosRastreio;

namespace RasReiios.rastrear
{
    public class Rastreando
    {
        public string CodigoRastreio { get; set; }

        public Rastreando(string CodigoRastreio)
        {
            this.CodigoRastreio = CodigoRastreio;
        }

        public RasReiios.DadosRastreio.Root GetInfoRs()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri($"https://proxyapp.correios.com.br/v1/sro-rastro/{CodigoRastreio}");
            request.Method = HttpMethod.Get;

            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.142 Safari/537.36");

            var response = client.Send(request);
//obter o json retornado
            var result = response.Content.ReadAsStringAsync().Result;

            //transformar o json em objetos csharp
        var json = JsonConvert.DeserializeObject<Root>(result);

            return json;
        }

    }
}
