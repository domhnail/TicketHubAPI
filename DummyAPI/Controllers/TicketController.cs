using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace TicketingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly IConfiguration _configuration;

        public TicketController(ILogger<TicketController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ticket ticket)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            string queueName = "tickethub";
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Azure Storage connection string is missing.");
                return StatusCode(500, "Storage configuration error.");
            }

            try
            {
                var queueClient = new QueueClient(connectionString, queueName);

                string message = JsonSerializer.Serialize(ticket);
                await queueClient.SendMessageAsync(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message)));

                _logger.LogInformation("Ticket successfully queued.");
                return Ok("Ticket successfully added to the queue.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending ticket to the queue.");
                return StatusCode(500, "Internal server error. Try again later.");
            }
        }
    }
}