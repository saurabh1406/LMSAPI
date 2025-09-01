using LMS.Application.DTOs;
using LMS.Application.Handlers.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSAPI.Controllers
{
    
    [ApiController]
    public class UserLoginController(ISender _sender) : ControllerBase
    {
        [HttpPost("api/UserRegistration")]
        public async Task<IActionResult> UserRegistration([FromBody] UserDetailsDTO userRegistration)
        {
             await _sender.Send(new UserCreationCommand(userRegistration));
            return Ok(userRegistration);
        }


        [HttpPost("api/UserLogin")]
        public async Task<IActionResult> UserLogin(string email, string password)
        {
            var result = await _sender.Send(new UserLoginCommand(email, password));
            return Ok(result);
        }
    }
}
