using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PollenApp.Models;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public List<PollenData> PollenCounts { get; set; } = new();
    public string PollenHtml { get; set; } = string.Empty;

    public IndexModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task OnGetAsync()
    {
        var regions = new List<(string id, string name)>
        {
            ("2a2a2a2a-2a2a-4a2a-aa2a-2a2a303a3137", "Sundsvall"),
            ("2a2a2a2a-2a2a-4a2a-aa2a-2a2a2a303a32", "Stockholm"),
            ("2a2a2a2a-2a2a-4a2a-aa2a-2a2a2a303a38", "Göteborg"),
            ("2a2a2a2a-2a2a-4a2a-aa2a-2a2a2a303a39", "Malmö")
        };

        foreach (var region in regions)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://api.pollenrapporten.se/v1/forecasts?region_id={region.id}&current=true");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var pollenResponse = JsonSerializer.Deserialize<PollenApiResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (pollenResponse?.Items != null)
                    {
                        GeneratePollenHtml(pollenResponse.Items, region.name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pollen data for {region.name}: {ex.Message}");
            }
        }
    }

    private void GeneratePollenHtml(List<PollenData> forecasts, string regionName)
    {
        var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
        foreach (var forecast in forecasts)
        {
            var todayLevel = forecast.LevelSeries?.Find(level => level.Time.Split('T')[0] == today);
            var level = todayLevel?.Level ?? -1;
            var iconPath = GetPollenIcon(level);
            PollenHtml += $@"
            <div class='pollen-card'>
                <h3>Pollenprognos för {regionName}</h3>
                <p><strong>Startdatum:</strong> {forecast.StartDate ?? "Okänt"}</p>
                <p><strong>Slutdatum:</strong> {forecast.EndDate ?? "Okänt"}</p>
                <p><strong>Beskrivning:</strong> {forecast.Text ?? "Ingen beskrivning tillgänglig."}</p>
                <p><strong>Nivå idag:</strong> {(level != -1 ? level.ToString() : "Ingen data tillgänglig.")}</p>
                <div class='pollen-icon'>
                    <img src='{iconPath}' alt='Pollen level icon'>
                </div>
            </div>";
        }
    }

    public string GetPollenIcon(int level)
    {
        return level switch
        {
            0 => "/images/none.png",
            1 => "/images/very-low.png",
            2 => "/images/low.png",
            3 or 4 => "/images/medium.png",
            5 or 6 => "/images/high.png",
            7 => "/images/very-high.png",
            _ => "/images/unknown.png"
        };
    }
}

public class PollenApiResponse
{
    public List<PollenData> Items { get; set; } = new();
}

public class PollenData
{
    public string PollenType { get; set; }
    public List<LevelSeries> LevelSeries { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Text { get; set; }
}

public class LevelSeries
{
    public string Time { get; set; }
    public int Level { get; set; }
}
