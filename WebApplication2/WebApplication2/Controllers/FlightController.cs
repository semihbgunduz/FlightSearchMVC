using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication2.Models;
using System.Diagnostics;
using System.Text;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AirSearchService _airService;

        public HomeController(ILogger<HomeController> logger,AirSearchService airService)
        {
            _logger = logger;
            _airService = airService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new FlightSearchModel
            {
                DepartureDate = DateTime.Today,
                ReturnDate = DateTime.Today,
                PassengerCount = 1
            };
            var airportsResponse = await _airService.GetAirportsAsync();
            var airports = JsonSerializer.Deserialize<List<Airport>>(airportsResponse);

            ViewBag.Airports = airports;
            return View(model);
        }

        [HttpPost("home/search")]
        public async Task<IActionResult> Search(FlightSearchModel model)
        {
            var request = new SearchRequest
            {
                DepartureDate = model.DepartureDate,
                Destination = model.DestinationCity,
                Origin = model.DepartureCity
            };

            // Check if ReturnDate is selected
            if (model.RoundTrip && model.ReturnDate.HasValue)
            {
                request.ReturnDate = model.ReturnDate.Value;
            }

            var response = await _airService.SearchAvailabilityAsync(request);
            var result = JsonSerializer.Deserialize<SearchResponse>(response);
            var flightOptions = result?.Body?.AvailabilitySearchResponse?.AvailabilitySearchResult?.FlightOptions;

            return View("Results", flightOptions);
        }


        [HttpGet("home/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("home/error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("home/detail/{flightNumber}")]
        public IActionResult GetFlightDetail(string flightNumber)
        {
            var flightDetail = new
            {
                FlightNumber = flightNumber,
                AircraftType = "Boeing 737",
                Duration = "2h 45m",
                Meals = "Included",
                Entertainment = "In-flight Entertainment System"
            };

            return Json(flightDetail);
        }
    }
}
