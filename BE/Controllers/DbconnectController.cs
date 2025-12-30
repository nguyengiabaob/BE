using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DefaultService _defaultService { get; set; }

        public UserController(DefaultService defaultService)
        {
            _defaultService = defaultService;
        }
        [HttpGet("AllRetaurant")]
        public object GetRetaurant()
        {
            return _defaultService.GetStudent();
        }
    }
}