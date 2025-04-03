using System.Text.Json;
using System.Text;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;

namespace TicketHub_API_W0484847.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPurchaseController : ControllerBase
    {
        private readonly ILogger<TicketPurchaseController> _logger;
        private readonly IConfiguration _configuration;

        public TicketPurchaseController(
            ILogger<TicketPurchaseController> logger,
            IConfiguration configuration
        )
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from TicketHub Controller - GET()");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketPurchase ticketPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Connection string is not configured properly." }
                );
            }

            string queueName = "tickethub";
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            string message = JsonSerializer.Serialize(ticketPurchase);

            try
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(message);
                await queueClient.SendMessageAsync(Convert.ToBase64String(plainTextBytes));
                return Ok(new { message = "Ticket purchase successfully queued." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending message to Azure Queue");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Error while processing the request.", error = ex.Message }
                );
            }
        }
    }
}