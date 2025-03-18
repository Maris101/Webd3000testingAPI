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
        public IActionResult Post(Contact contact)
        {
            //Validation:
            if (string.IsNullOrEmpty(contact.FirstName))
            {
                return BadRequest("First Name is invalid.");
            }

            //Validation:
            if (string.IsNullOrEmpty(contact.LastName))
            {
                return BadRequest("Last Name is invalid.");
            }





            return Ok("Hello" + contact.FirstName + "from the Contacts Controller - POST");
        }








    }
}
