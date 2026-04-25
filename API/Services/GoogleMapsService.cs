using API.Config;
using DTO;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Services
{
    public class GoogleMapsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GoogleMapsService(HttpClient httpClient, IOptions<GoogleMapsOptions> options)
        {
            _httpClient = httpClient;
            _apiKey = options.Value.ApiKey;
        }

        public async Task<LocationDTO?> GeocodeAddressAsync(string address)
        {
            var encodedAddress = Uri.EscapeDataString(address);
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedAddress}&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(json);
            var root = document.RootElement;

            var status = root.GetProperty("status").GetString();

            if (status != "OK")
                return null;

            var result = root.GetProperty("results")[0];

            var location = result.GetProperty("geometry").GetProperty("location");

            return new LocationDTO
            {
                Address = result.GetProperty("formatted_address").GetString() ?? "",
                Latitude = location.GetProperty("lat").GetDecimal(),
                Longitude = location.GetProperty("lng").GetDecimal(),
                PlaceId = result.GetProperty("place_id").GetString() ?? ""
            };
        }

        public async Task<LocationDTO?> ReverseGeocodeAsync(decimal lat, decimal lng)
        {
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lng}&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(json);
            var root = document.RootElement;

            var status = root.GetProperty("status").GetString();

            if (status != "OK")
                return null;

            var result = root.GetProperty("results")[0];

            return new LocationDTO
            {
                Address = result.GetProperty("formatted_address").GetString() ?? "",
                Latitude = lat,
                Longitude = lng,
                PlaceId = result.GetProperty("place_id").GetString() ?? ""
            };
        }

        public async Task<string> GeocodeAddressRawAsync(string address)
        {
            var encodedAddress = Uri.EscapeDataString(address);
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedAddress}&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }


    }
}