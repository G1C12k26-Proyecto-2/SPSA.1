using API.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapsController : ControllerBase
    {
        private readonly GoogleMapsService _googleMapsService;

        public MapsController(GoogleMapsService googleMapsService)
        {
            _googleMapsService = googleMapsService;
        }

        [HttpGet("geocode")]
        public async Task<ApiResponse> Geocode([FromQuery] string address)
        {
            var response = new ApiResponse();

            try
            {
                var location = await _googleMapsService.GeocodeAddressAsync(address);

                if (location == null)
                {
                    response.Result = "error";
                    response.Message = "Location not found.";
                    return response;
                }

                response.Result = "ok";
                response.Data = location;
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("reverse-geocode")]
        public async Task<ApiResponse> ReverseGeocode([FromQuery] decimal latitude, [FromQuery] decimal longitude)
        {
            var response = new ApiResponse();

            try
            {
                // Basic validation (helps avoid nonsense calls)
                if (latitude == 0 || longitude == 0)
                {
                    response.Result = "error";
                    response.Message = "Invalid coordinates.";
                    return response;
                }

                var location = await _googleMapsService.ReverseGeocodeAsync(latitude, longitude);

                if (location == null)
                {
                    response.Result = "error";
                    response.Message = "No address found for the given coordinates.";
                    return response;
                }

                response.Result = "ok";
                response.Data = location;
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
