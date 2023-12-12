using Newtonsoft.Json;
using System.Text.Json;

namespace CustomerManagement.Web.Clients.ViaCep
{
    public class ViaCepClient : IViaCepClient
    {
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;
        public ViaCepClient(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ViaCepResponse> GetAsync(string cep)
        {
            //HttpClient cliente = new HttpClient();
            //HttpResponseMessage resposta = await cliente.GetAsync("https://viacep.com.br/ws/01001000/json/");
            //resposta.EnsureSuccessStatusCode();

            //return await resposta.Content.ReadAsStringAsync();

            cep = "14020689";
            var client = _clientFactory.CreateClient("ViaCepClient");
            string apiUrl = $"/ws/{cep}/json";
            try
            {
                var response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode) new Exception($"ViaCep: {response.StatusCode}");

                //var apiResponse = await response.Content.ReadAsStreamAsync();
                var apiResponse = await response.Content.ReadAsStringAsync();


                //return await System.Text.Json.JsonSerializer.DeserializeAsync<ViaCepResponse>(apiResponse, _options);
                var result = JsonConvert.DeserializeObject<ViaCepResponse>(apiResponse);
                return result;
                //return new ViaCepResponse();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ViaCep: {ex.Message}");
            }
        }

        //public ViaCepResponse Get(string cep)
        //{
        //    HttpClient cliente = new HttpClient();
        //    HttpResponseMessage resposta = await cliente.GetAsync("https://viacep.com.br/ws/01001000/json/");
        //    resposta.EnsureSuccessStatusCode();

        //    return await resposta.Content.ReadAsStringAsync();
        //}
    }
}
