using System.Text.Json.Serialization;
namespace PollenApp.Models
{

    public class PollenData
    {
        [JsonPropertyName("pollen_type")]
        public string PollenType { get; set; } = "";

        [JsonPropertyName("level")]
        public int Level { get; set; } // Numeric level (0-7)

        [JsonPropertyName("name")]
        public string Name { get; set; } = ""; // Text description ("Låga", "Höga", etc.)
    }

}
