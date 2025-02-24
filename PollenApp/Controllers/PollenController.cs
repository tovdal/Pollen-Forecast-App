using Microsoft.AspNetCore.Mvc;

namespace PollenApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollenController : ControllerBase
    {
        [HttpGet("types")]
        public IActionResult GetPollenTypes()
        {
            var pollenTypes = new[]
            {
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323236", Name = "Al", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323236&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323533", Name = "Malörtsambrosia", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323533&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323530", Name = "Gråbo", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323530&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323332", Name = "Björk", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323332&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323233", Name = "Hassel", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323233&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323335", Name = "Bok", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323335&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323433", Name = "Gräs", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323433&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323337", Name = "Ek", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323337&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323330", Name = "Sälg och viden", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323330&current=true" },
                new { Id = "2a2a2a2a-2a2a-4a2a-aa2a-2a313a323331", Name = "Alm", Forecasts = "https://api.pollenrapporten.se/v1/forecasts?pollen_id=2a2a2a2a-2a2a-4a2a-aa2a-2a313a323331&current=true" }
            };

            return Ok(new { Items = pollenTypes });
        }
    }
}