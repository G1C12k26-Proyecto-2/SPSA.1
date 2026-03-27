using AppLogic;
using AppLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IAuthManager _authManager;

        public AuthController(IUserManager userManager, IAuthManager authManager)
        {
            _userManager = userManager;
            _authManager = authManager;
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

                var safeUser = new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    Rol = user.Rol
                };

                response.Data = safeUser;
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("CreateUserWithRole")]
        public ApiResponse CreateUserWithRole([FromBody] CreateUserDTO newUser)
        {
            var response = new ApiResponse();

            try
            {
                if (newUser.Rol != "Admin" && newUser.Rol != "Funcionario")
                {
                    response.Result = "error";
                    response.Message = "Invalid role";
                    return response;
                }

                _userManager.CreateUser(newUser, newUser.Rol);

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

        [HttpPost("CreatePropietario")]
        public ApiResponse CreatePropietario([FromBody] CreateUserDTO newUser)
        {
            var response = new ApiResponse();

            try
            {
                _userManager.CreateUser(newUser, "Propietario");

                response.Result = "ok";
                response.Message = "Propietario created successfully";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            _authManager.ForgotPassword(request.Email);
            return Ok(new { message = "If the email exists, a reset link was sent." });
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDTO request)
        {
            _authManager.ResetPassword(request.Token, request.NewPassword);
            return Ok(new { message = "Password updated successfully" });
        }
    }
}