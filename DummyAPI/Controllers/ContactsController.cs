using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;

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
        public async Task<IActionResult> Post(Contact contact)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            string queueName = "contacts";
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("No connection string.");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            //// serialize an object to json
            string message = JsonSerializer.Serialize(contact);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok("Hello " + contact.FirstName + ". i am in your storage queue.");
        }
    }
}
