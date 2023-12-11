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
            var client = _clientFactory.CreateClient("ViaCepClient");
            string apiUrl = $"ws/{cep}/json/";
            try
            {
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode) new Exception($"ViaCep: {response.StatusCode}");

                var apiResponse = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ViaCepResponse>(apiResponse, _options);
            }
            catch (Exception ex)
            {                
                throw new Exception($"Error ViaCep: {ex.Message}");
            }                   
        }
    }
}
