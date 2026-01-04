using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public DefaultService _defaultService { get; set; }

        public AuthController(DefaultService defaultService)
        {
            _defaultService = defaultService;
        }
        [HttpGet("AllRetaurant")]
        public async Task<object> GetRetaurant()
        {
            var a = await _defaultService.GetStudent();
            return  a;
        }
    }
}