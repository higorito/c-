using System.Text.Json;

namespace backendPicPay.Services.AutorizadorService;

public class AutorizadorService: IAutorizadorService
{   
    private readonly HttpClient _httpClient;
    
    private const string URL = "http://www.picpay.com.br/autorizador";
    
    public AutorizadorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<bool> AutorizarAsync()
    {
        string content = string.Empty;

        // nao funciona mais a url
        // var response = await _httpClient.GetAsync(URL);
        // 
        // if (!response.IsSuccessStatusCode)
        //     return false;
        // 
        // response.EnsureSuccessStatusCode();
        // 
        // content = await response.Content.ReadAsStringAsync();
        // 
        // var result = JsonSerializer.Deserialize<ApiResponse>(content);
        // 
        //return result.status == "Autorizado";
        return true;
    }
    
    private partial class ApiResponse
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}

