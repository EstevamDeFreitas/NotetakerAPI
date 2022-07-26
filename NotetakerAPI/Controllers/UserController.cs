using Microsoft.AspNetCore.Mvc;
using Service.DTO.User;
using Service.Notations;
using Service.Response;
using Service.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceWrapper _services;
        public UserController(IServiceWrapper services)
        {
            _services = services;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult LoginUser(UserDto user)
        {
            try
            {
                var token = _services.UserService.GenerateToken(user);

                return Ok(new Response<string>
                {
                    Data = token,
                    Message = "Token generated"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateDto user)
        {
            try
            {
                _services.UserService.Create(user);

                return Ok(new Response<object>
                {
                    Message = "User created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateUser(UserUpdateDto user)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.AccessVerifier.VerifyAccess(userId, user.Email);

                _services.UserService.Update(user);

                return Ok(new Response<object>
                {
                    Message = "User updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(UserDto user)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.UserService.Delete(user, userId);

                return Ok(new Response<object>
                {
                    Message = "User deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

    }
}

