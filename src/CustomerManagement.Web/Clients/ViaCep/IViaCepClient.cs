namespace CustomerManagement.Web.Clients.ViaCep
{
    public interface IViaCepClient
    {
        Task<ViaCepResponse> GetAsync(string cep);
    }
}
