using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IConfiguration _configuration;

        public ContactsController(ILogger<ContactsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello i am under water.");
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName))
            {
                return BadRequest("Invalid first name");
            }
            if (string.IsNullOrEmpty(contact.LastName))
            {
                return BadRequest("Invalid last name");
            }
            return Ok("Hello " + contact.FirstName + " i am in the air.");
        }
    }
}
