using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<Student> _usercollection;
        [HttpGet]
        public string Get()
        {
            return "Hello from DBConnectController";
        }
    }
}