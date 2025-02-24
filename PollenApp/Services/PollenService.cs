using PollenApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class PollenService
{
    private readonly HttpClient _httpClient;

    public PollenService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PollenApiResponse> GetPollenTypesAsync()
    {
        string url = "https://api.pollenrapporten.se/v1/pollen-types?offset=0&limit=100";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PollenApiResponse>(responseBody);
    }
}