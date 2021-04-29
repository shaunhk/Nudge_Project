using System;
using System.Collections.Generic;

namespace NVS_Project.Models
{
    public class UserRepository
    {
        private List<userDetails> users = new List<userDetails>();
        private int _nextId = 1;

        public List<userDetails> GetAll()
        {
           return users;
           
        }

     
        public userDetails Add(userDetails item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.studentID = _nextId++;
            users.Add(item);
            return item;
        }
    }
}