using Azure;
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
            if(string.IsNullOrWhiteSpace(cep)) throw new Exception($"ViaCep: Informa CEP válido.");

            var client = _clientFactory.CreateClient("ViaCepClient");
            string apiUrl = $"/ws/{cep.Replace("-", "")}/json";
            try
            {
                var response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode) throw new Exception($"ViaCep: {response.StatusCode}");

                var apiResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ViaCepResponse>(apiResponse);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ViaCep: {ex.Message}");
            }
        }
    }
}
