using BusinessLayer;
using BusinessLayer.Services;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;

        public AuthController(ITokenService tokenService, IAccountService accountService)
        {
            _tokenService = tokenService;
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var account = await _accountService.GetAccountWithUsernameAndPassword(login.Username, login.Password);

            if (account == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(account);
            return Ok(new { Token = token });
        }
    }

}
