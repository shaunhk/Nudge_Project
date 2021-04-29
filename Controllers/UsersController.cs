using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace groupbackend.Controllers
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
        public IEnumerable<Models.userDetails> GetAllUsers()
        {
            return repository.GetAll();
        }

        [HttpPost]
        [Route("api/user")]
        [Consumes("application/json")]
        public Models.userDetails PostUser(Models.userDetails item)
        {
            return repository.Add(item);
        }
        

    }
}