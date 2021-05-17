using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using NVS_Project.Models;

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
        public async Task<ActionResult<Models.userDetails>> PostUser(Models.userDetails userInfo)
        {
            string url = "https://apitest.hedd.ac.uk:8443/enquiries/verify";


            // Below is method attempted, didnt work
            /*
            JObject rss =
                new JObject(
                    new JProperty("enquiry-type", userInfo.enquirytype),
                    new JProperty("first-names", userInfo.firstName),
                    new JProperty("last-name", userInfo.lastName),
                    new JProperty("date-of-birth", userInfo.DOB.ToString("yyyy-MM-dd"),
                    new JProperty("institution",
                        new JObject(
                            new JProperty("id", userInfo.institution.id)
                        )),
                    new JProperty("year-of-award", userInfo.yearOfAward),
                    new JProperty("course-name", userInfo.courseName),
                    new JProperty("qualification-type", userInfo.qualificationType),
                    new JProperty("classification", userInfo.classification),
                    new JProperty("documents",
                        new JArray(
                            new JObject(
                                new JProperty("name", userInfo.documents[0].name),
                                new JProperty("type", userInfo.documents[0].type),
                                new JProperty("content", userInfo.documents[0].content),
                                new JProperty("format", userInfo.documents[0].format)
                        )))
                ));
            */

            // This is the closest to it working
            string json = "{enquiry-type: '"+userInfo.enquirytype + "'," +
                "first-names: '" + userInfo.firstName + "'," +
                "last-name: '" + userInfo.lastName + "'," +
                "date-of-birth: '" + userInfo.DOB.ToString("yyyy-MM-dd") + "'," +
                "institution : {id: '" + userInfo.institution.id + "'," +
                "year-of-award: '" + userInfo.yearOfAward + "'," +
                "course-name: '"+ userInfo.courseName + "'," +
                "qualification-type: '"+ userInfo.qualificationType + "'," +
                "classification: '"+ userInfo.classification + "'," +
                "documents: [{ name: '"+ userInfo.documents[0].name + "'," +
                "type: '" + userInfo.documents[0].type + "'," +
                "content: '" + userInfo.documents[0].content + "'," +
                "format: '" + userInfo.documents[0].format + "' }]  }";

            //var serializedContents = JsonSerializer.Serialize(json);
            Console.WriteLine(json);

            using (var client = new System.Net.WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers.Add("api-key", "00B07655-E61F-4A4E-BDF7-4DC61A4BA8DF");
                try
                {
                    client.UploadString(url, json);
                    return Ok(json);
                } catch {
                    throw;
                }
            }

        }
    }
}