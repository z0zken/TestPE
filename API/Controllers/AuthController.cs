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
        private readonly ApplicationContext _context;

        public AuthController(ITokenService tokenService, ApplicationContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var account = await _context.Account
                .FirstOrDefaultAsync(a => a.Username == login.Username && a.Password == login.Password);

            if (account == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(account);
            return Ok(new { Token = token });
        }
    }

}
