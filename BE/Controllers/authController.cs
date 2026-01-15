using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService { get; set; }

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Resgister")]
        public async Task<object> Resgister(RegisterData data)
        {
            var a = await _authService.Resgister(data);
            return a;
        }
    }
}