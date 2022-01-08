using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Contracts;
using AuthService.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }

        [HttpPost("token")]
        public IActionResult Token([FromBody] CredentialModel model)
        {
            try
            {
                var token = _authService.GetToken(model);

                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
