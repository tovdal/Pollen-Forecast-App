using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PollenApp.Models;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public List<PollenData> PollenCounts { get; set; } = new();

    public IndexModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task OnGetAsync()
    {
        string regionId = "2a2a2a2a-2a2a-4a2a-aa2a-2a2a303a3137"; // Sundsvall's region ID
        string url = $"https://api.pollenrapporten.se/v1/pollen-count?region_id={regionId}&offset=0&limit=100";

        try
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pollenResponse = JsonSerializer.Deserialize<PollenApiResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                PollenCounts = pollenResponse?.Items ?? new();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching pollen data: {ex.Message}");
        }
    }

    public string GetPollenIcon(string levelName)
    {
        return levelName switch
        {
            "Inga halter" => "/images/none.png",
            "Låga" or "Låga till måttliga" => "/images/low.png",
            "Måttliga" or "Måttliga till höga" => "/images/medium.png",
            "Höga" or "Höga till mycket höga" => "/images/high.png",
            "Mycket höga" => "/images/very-high.png",
            _ => "/images/unknown.png"
        };
    }
}

public class PollenApiResponse
{
    public List<PollenData> Items { get; set; } = new();
}
