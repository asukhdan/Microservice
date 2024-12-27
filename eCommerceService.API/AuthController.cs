using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceService.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IUserService _userService;
        
        public AuthController(IUserService userService)
        {
            _userService = userService;
          
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return  BadRequest("Invalid Register Data");
            }
            AuthenticationResponse? authenticationResponse = await _userService.RegisterUser(registerRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                 return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

         [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if(loginRequest==null)
            {
                return BadRequest("Invalid Login Data");
            }
            AuthenticationResponse? authenticationResponse= await _userService.Login(loginRequest);
            if(authenticationResponse==null || authenticationResponse.Success==false)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);

        }
    }
}
