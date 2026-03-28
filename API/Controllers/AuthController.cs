using AppLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

                response.Data = new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    Rol = user.Rol
                };
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

        [HttpPost("ForgotPassword")]
        public ApiResponse ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var response = new ApiResponse();

            try
            {
                _authManager.ForgotPassword(request.Email);
                response.Result = "ok";
                response.Message = "If the email exists, a reset link was sent.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("ResetPassword")]
        public ApiResponse ResetPassword([FromBody] ResetPasswordDTO request)
        {
            var response = new ApiResponse();

            try
            {
                _authManager.ResetPassword(request.Token, request.NewPassword);
                response.Result = "ok";
                response.Message = "Password updated successfully";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("GetAllUsers")]
        public ApiResponse GetAllUsers()
        {
            var response = new ApiResponse();

            try
            {
                var users = _userManager.RetrieveAllUsers();

                response.Data = users.Select(user => new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    Rol = user.Rol
                }).ToList();

                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut("UpdateUser")]
        public ApiResponse UpdateUser([FromBody] UpdateUserDTO updatedUser)
        {
            var response = new ApiResponse();

            try
            {
                _userManager.UpdateUser(updatedUser);
                response.Result = "ok";
                response.Message = "User updated successfully";
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
}