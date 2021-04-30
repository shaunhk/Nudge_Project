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

    }

    public class institution 
    {
      public int id {get; set;}
    }

}

    