using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NVS_Project.Models
{
    public class userDetails
    {
        public userDetails()
        {

        }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime DOB { get; set; }

        public virtual institution institution { get; set; }

        public string courseName { get; set; }

        public string yearOfAward { get; set; }

        public string qualificationType { get; set; }

        public string classification { get; set; }

        // https://stackoverflow.com/questions/21578814/how-to-receive-json-as-an-mvc-5-action-method-parameter
        public List<document> documents { get; set;  }

    }

    public class institution 
    {
      public int id {get; set;}
    }

    public class document
    {

        public string name { get; set; }

        public string type { get; set; }

        public string content { get; set; }

        public string format { get; set; }
    }


}
    