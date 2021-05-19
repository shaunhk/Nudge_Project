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
using System.IO;

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
            var rss =
                new JObjec(
                    new JProperty("enquiry-type", userInfo.enquirytype),
                    new JProperty("first-names", userInfo.firstName),
                    new JProperty("last-name", userInfo.lastName),
                    new JProperty("date-of-birth", userInfo.DOB
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

            //Console.WriteLine(serializedContents);


            var preparedUser = new Dictionary<string, object>
            {
                { "enquiry-type", userInfo.enquirytype },
                {"first-names", userInfo.firstName },
                {"last-name", userInfo.lastName },
                {"date-of-birth", userInfo.DOB },
                {"institution",userInfo.institution },
                {"year-of-award", userInfo.yearOfAward },
                {"course-name", userInfo.courseName },
                {"qualification-type", userInfo.qualificationType },
                {"classification", userInfo.classification },
                {"documents", userInfo.documents }
            };
            var serializedContents = JsonSerializer.Serialize(preparedUser);

            using (var client = new System.Net.WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers.Add("api-key", "00B07655-E61F-4A4E-BDF7-4DC61A4BA8DF");
                try
                {
                    client.UploadString(url, serializedContents);
                    return Ok();
                }
                catch (WebException e)
                {
                    //The following error handling should be more helpful for debugging in development stage
                    Console.WriteLine("This program is expected to throw WebException on successful run." +
                              "\n\nException Message :" + e.Message);
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                        Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                        StreamReader r = new StreamReader(((HttpWebResponse)e.Response).GetResponseStream());
                        Console.WriteLine("Content: {0}", r.ReadToEnd());
                    }
                    return (BadRequest());
                }
            }

        }
    }
}