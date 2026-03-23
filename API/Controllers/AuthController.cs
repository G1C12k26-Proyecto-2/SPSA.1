using AppLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Login")]
        public ApiResponse Login([FromBody] LoginDTO login)
        {
            var response = new ApiResponse();

            try
            {
                var user = _userManager.ValidateUser(login.UserName, login.Password);

                if (user == null)
                {
                    response.Result = "error";
                    response.Message = "Invalid username or password";
                    return response;
                }

                response.Data = user;
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("CreateUser")]
        public ApiResponse CreateUser([FromBody] CreateUserDTO newUser)
        {
            var response = new ApiResponse();

            try
            {
                _userManager.CreateUser(newUser);
                response.Result = "ok";
                response.Message = "User created successfully";
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