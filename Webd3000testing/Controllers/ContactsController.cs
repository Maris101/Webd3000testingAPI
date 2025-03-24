using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webd3000testing.Controllers
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
            return Ok("Hello from the Contacts Controller - GET");
        }



        [HttpPost]
        public async Task <IActionResult> Post(Contact contact)
        {

            //Validation classes: 
            //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-9.0

            //This uses the validation inside Contact.cs
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            //
            // Post contact to queue
            //

            string queueName = "contacts";

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(contact);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            
            //await queueClient.SendMessageAsync("Hello from the API App!");


            return Ok("Sucess - message posted to Storage Queue");
        }








    }
}
