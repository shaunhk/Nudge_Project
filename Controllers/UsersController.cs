using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NVS_Project.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;

        static readonly Models.IUserRepository repository = new Models.UserRepository();

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/users")]
        public IEnumerable<Models.userDetails> Get()
        {

            return repository.GetAll();
        }

        [HttpPost]
        [Route("api/user")]
        [Consumes("application/json")]
        public IActionResult PostUser(Models.userDetails userInfo)
        {
            string url = "https://apitest.hedd.ac.uk:8443";

            var serializedContents = JsonSerializer.Serialize(userInfo);

            /*
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                //client.Headers["Authorization"] = "1DTLNLZ9PS2YLD0KOMKZ1DTLNLZ9PS2YLD0KOMK";
                string s = client.UploadString(url, serializedContents);
                Console.WriteLine(s);
            }
            */
            return Ok(serializedContents);
            //var result = userInfo; 
            //return Ok(result);
        }
    }
}