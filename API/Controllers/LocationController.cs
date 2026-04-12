using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpPost("Create")]
        public ApiResponse Create([FromBody] LocationDTO location)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new LocationManager();
                manager.Create(location);

                response.Result = "ok";
                response.Message = "Location created successfully.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("RetrieveAll")]
        public ApiResponse RetrieveAll()
        {
            var response = new ApiResponse();

            try
            {
                var manager = new LocationManager();
                response.Data = manager.RetrieveAll();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("RetrieveById")]
        public ApiResponse RetrieveById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new LocationManager();
                var location = manager.RetrieveById(id);

                if (location == null)
                {
                    response.Result = "error";
                    response.Message = "Location not found.";
                    return response;
                }

                response.Data = location;
                response.Result = "ok";
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